using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

using AutoMapper;

using Dess.Api.Entities;
using Dess.Api.Helpers;
using Dess.Api.Hubs;
using Dess.Api.Models;
using Dess.Api.Models.ElectroFence;
using Dess.Api.Repositories;

namespace Dess.Api.Controllers
{
  [AllowAnonymous]
  [ApiController]
  [Route("api/hw")]
  public class ElectroFenceRepository : ControllerBase
  {
    private readonly IElectroFenceRepository _repository;
    private readonly IUserLogRepository _userLogRepository;
    private readonly IMapper _mapper;
    private readonly IHubContext<ElectroFenceHub> _hubContext;

    public ElectroFenceRepository(IElectroFenceRepository electroFenceRepository, IUserLogRepository userLogRepository, IMapper mapper, IHubContext<ElectroFenceHub> hubContext)
    {
      _repository = electroFenceRepository ??
        throw new ArgumentNullException(nameof(electroFenceRepository));

      _userLogRepository = userLogRepository ??
        throw new ArgumentNullException(nameof(userLogRepository));

      _mapper = mapper ??
        throw new ArgumentNullException(nameof(mapper));

      _hubContext = hubContext ??
        throw new ArgumentNullException(nameof(_hubContext));
    }

    [HttpPost("{siteId}/{configHash}")]
    public async Task<IActionResult> UpdateAsync(string siteId, string configHash, [FromBody] ElectroFenceStatusFromHwDto status)
    {
      var ef = await _repository.GetAsync(siteId);

      if (ef == null)
        return NotFound();

      var statusDto = _mapper.Map<ElectroFenceStatusDto>(status);
      statusDto.IpAddress = HttpContext.Connection.RemoteIpAddress.ToString();
      statusDto.SiteId = ef.Id;
      statusDto.Date = DateTime.UtcNow.JavascriptDate();
      await _hubContext.Clients.All.SendAsync("UpdateStatus", statusDto);

      var statusEntity = _mapper.Map<ElectroFenceStatus>(status);
      statusEntity.Date = DateTime.UtcNow;
      ef.Applied = configHash == ef.Hash;

      var statusFromRepo = await _repository.GetStatusAsync(ef.Id);
      var statusHash = (status as IHashable).GetHash();

      if (statusFromRepo.Hash != statusHash)
      {
        statusEntity.Hash = statusHash;
        ef.Log.Add(statusEntity);
        await _repository.SaveAsync();

        ElectroFenceHub.UserIds.ForEach(
          id => _userLogRepository.Add(
            new UserLog { UserId = id, LogId = statusEntity.Id }));

        await _userLogRepository.SaveAsync();
      }

      else
      {
        _mapper.Map(statusFromRepo, statusEntity);
        _repository.UpdateLog(statusFromRepo);
      }

      if (ef.AutoLocation)
      {
        ef.Latitude = status.Latitude;
        ef.Longitude = status.Longitude;
      }

      await _repository.SaveAsync();

      if (ef.Applied)
        return NoContent();

      return Ok(_mapper.Map<ElectroFenceForHwDto>(ef));
    }

    [HttpGet("{siteId}")]
    public async Task<ActionResult<ElectroFenceForHwDto>> GetConfig(string siteId)
    {
      var ef = await _repository.GetAsync(siteId);

      if (ef == null)
        return NotFound();

      return Ok(_mapper.Map<ElectroFenceForHwDto>(ef));
    }
  }
}