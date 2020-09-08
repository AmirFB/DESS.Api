using System;
using System.Threading.Tasks;
using AutoMapper;
using Dess.Hubs;
using Dess.Models;
using Dess.Models.ElectroFence;
using Dess.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Dess.Controllers
{
  [ApiController]
  [Route("api/irancell/hw")]
  public class ElectroFenceRepository : ControllerBase
  {
    private readonly IElectroFenceRepository _repository;
    private readonly IMapper _mapper;
    private readonly IHubContext<ElectroFenceHub> _hubContext;

    public ElectroFenceRepository(IElectroFenceRepository electroFenceRepository, IMapper mapper, IHubContext<ElectroFenceHub> hubContext)
    {
      _repository = electroFenceRepository ??
          throw new ArgumentNullException(nameof(electroFenceRepository));

      _mapper = mapper ??
          throw new ArgumentNullException(nameof(mapper));

      _hubContext = hubContext ??
          throw new ArgumentNullException(nameof(_hubContext));
    }

    [HttpPost("{serial}/{configHash}")]
    public async Task<IActionResult> UpdateAsync(string serial, string configHash, [FromBody] ElectroFenceStatusFromHwDto status)
    {
      var ef = await _repository.GetAsync(serial);

      if (ef == null)
        return NotFound();

      var statusDto = _mapper.Map<ElectroFenceDto>(status);
      await _hubContext.Clients.All.SendAsync("UpdateStatus", statusDto);

      _mapper.Map(status, ef.Status);
      ef.Status.Date = DateTime.Now;
      ef.Applied = configHash == ef.Hash;

      var statusHash = (status as IHashable).GetHash();

      if (ef.Status.Hash != statusHash)
      {
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

    [HttpGet("{serial}")]
    public async Task<ActionResult<ElectroFenceForHwDto>> GetConfig(string serial)
    {
      var ef = await _repository.GetAsync(serial);

      if (ef == null)
        return NotFound();

      return Ok(_mapper.Map<ElectroFenceForHwDto>(ef));
    }
  }
}