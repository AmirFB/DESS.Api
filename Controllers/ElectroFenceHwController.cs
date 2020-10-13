using System;
using System.Threading.Tasks;
using AutoMapper;
using Dess.Api.Entities;
using Dess.Api.Hubs;
using Dess.Api.Models;
using Dess.Api.Models.ElectroFence;
using Dess.Api.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

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
      await _hubContext.Clients.All.SendAsync("UpdateStatus", statusDto);

      _mapper.Map(status, ef.Status);
      ef.Status.Date = DateTime.Now;
      ef.Applied = configHash == ef.Hash;

      var statusHash = (status as IHashable).GetHash();

      if (ef.Status.Hash != statusHash)
      {
        ElectroFenceHub.UserIds.ForEach(
          id => _userLogRepository.Add(
            new UserLog { UserId = id, LogId = ef.Status.Id }));

        await _userLogRepository.SaveAsync();
        ef.Status.Hash = statusHash;
        ef.Log.Add(ef.Status);
      }

      if (ef.AutoLocation)
      {
        ef.Latitude = ef.Status.Latitude;
        ef.Longitude = ef.Status.Longitude;
      }

      await _repository.SaveAsync();
      return Ok(ef.Hash);
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