using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;

using Dess.Api.Entities;
using Dess.Api.Helpers;
using Dess.Api.Hubs;
using Dess.Api.Models;
using Dess.Api.Models.ElectroFence;
using Dess.Api.Repositories;
using Dess.Api.Types;

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
      _repository = electroFenceRepository
        ??
        throw new ArgumentNullException(nameof(electroFenceRepository));

      _userLogRepository = userLogRepository
        ??
        throw new ArgumentNullException(nameof(userLogRepository));

      _mapper = mapper
        ??
        throw new ArgumentNullException(nameof(mapper));

      _hubContext = hubContext
        ??
        throw new ArgumentNullException(nameof(_hubContext));
    }

    private ElectroFenceFault HandleHvFault(ElectroFenceStatus status, ElectroFenceFault fault, IEnumerable<int> users)
    {
      if (fault == null && status.HvAlarm)
      {
        var output = new ElectroFenceFault { ElectroFenceId = status.ElectroFenceId };
        output.OccuredOn = DateTime.UtcNow;
        output.Type = FaultType.Hv;
        foreach (var user in users) output.SeenBy.Add(user);
        return output;
      }

      if (fault != null && !status.HvAlarm)
        fault.ObviatedOn = DateTime.UtcNow;

      return null;
    }

    private ElectroFenceFault HandleLvFault(ElectroFenceStatus status, ElectroFenceFault fault, IEnumerable<int> users)
    {
      if (fault == null && status.LvAlarm)
      {
        var output = new ElectroFenceFault { ElectroFenceId = status.ElectroFenceId };
        output.OccuredOn = DateTime.UtcNow;
        output.Type = FaultType.Lv;
        foreach (var user in users) output.SeenBy.Add(user);
        return output;
      }

      if (fault != null && !status.LvAlarm)
        fault.ObviatedOn = DateTime.UtcNow;

      return null;
    }

    private ElectroFenceFault HandleTamperFault(ElectroFenceStatus status, ElectroFenceFault fault, IEnumerable<int> users)
    {
      if (fault == null && status.TamperAlarm)
      {
        var output = new ElectroFenceFault { ElectroFenceId = status.ElectroFenceId };
        output.OccuredOn = DateTime.UtcNow;
        output.Type = FaultType.Tamper;
        foreach (var user in users) output.SeenBy.Add(user);
        return output;
      }

      if (fault != null && !status.TamperAlarm)
        fault.ObviatedOn = DateTime.UtcNow;

      return null;
    }

    private ElectroFenceFault HandlePowerFault(ElectroFenceStatus status, ElectroFenceFault fault, IEnumerable<int> users)
    {
      if (fault == null && status.MainPowerFault)
      {
        var output = new ElectroFenceFault { ElectroFenceId = status.ElectroFenceId };
        output.OccuredOn = DateTime.UtcNow;
        output.Type = FaultType.Power;
        foreach (var user in users) output.SeenBy.Add(user);
        return output;
      }

      if (fault != null && !status.MainPowerFault)
        fault.ObviatedOn = DateTime.UtcNow;

      return null;
    }

    private ElectroFenceFault HandleInput1Fault(ElectroFenceStatus status, ElectroFenceFault fault, IEnumerable<int> users)
    {
      if (fault == null && status.Inputs[0])
      {
        var output = new ElectroFenceFault { ElectroFenceId = status.ElectroFenceId };
        output.OccuredOn = DateTime.UtcNow;
        output.Type = FaultType.Input1;
        foreach (var user in users) output.SeenBy.Add(user);
        return output;
      }

      if (fault != null && !status.Inputs[0])
        fault.ObviatedOn = DateTime.UtcNow;

      return null;
    }

    private ElectroFenceFault HandleInput2Fault(ElectroFenceStatus status, ElectroFenceFault fault, IEnumerable<int> users)
    {
      if (fault == null && status.Inputs[1])
      {
        var output = new ElectroFenceFault { ElectroFenceId = status.ElectroFenceId };
        output.OccuredOn = DateTime.UtcNow;
        output.Type = FaultType.Input2;
        foreach (var user in users) output.SeenBy.Add(user);
        return output;
      }

      if (fault != null && !status.Inputs[1])
        fault.ObviatedOn = DateTime.UtcNow;

      return null;
    }

    private IEnumerable<ElectroFenceFault> HandleFaults(ElectroFenceStatus status, IEnumerable<ElectroFenceFault> faults, IEnumerable<int> users)
    {
      yield return HandleHvFault(status, faults.FirstOrDefault(f => f.Type == FaultType.Hv), users);
      yield return HandleLvFault(status, faults.FirstOrDefault(f => f.Type == FaultType.Lv), users);
      yield return HandleTamperFault(status, faults.FirstOrDefault(f => f.Type == FaultType.Tamper), users);
      yield return HandlePowerFault(status, faults.FirstOrDefault(f => f.Type == FaultType.Power), users);
      yield return HandleInput1Fault(status, faults.FirstOrDefault(f => f.Type == FaultType.Input1), users);
      yield return HandleInput2Fault(status, faults.FirstOrDefault(f => f.Type == FaultType.Input2), users);
    }

    [HttpPost("{siteId}/{configHash}")]
    public async Task<IActionResult> UpdateAsync(string siteId, string configHash, [FromBody] ElectroFenceStatusFromHwDto status)
    {
      var ef = await _repository.GetAsync(siteId);

      if (ef == null)
        return BadRequest();

      var statusDto = _mapper.Map<ElectroFenceStatusDto>(status);
      statusDto.IpAddress = HttpContext.Connection.RemoteIpAddress.ToString();
      statusDto.SiteId = ef.Id;
      statusDto.Date = DateTime.UtcNow.JavascriptDate();
      await _hubContext.Clients.All.SendAsync("UpdateStatus", statusDto);

      _mapper.Map(status, ef.Status);
      ef.Status.IpAddress = HttpContext.Connection.RemoteIpAddress.ToString();
      ef.Status.Date = DateTime.UtcNow;
      ef.Applied = configHash == ef.Hash;

      var statusHash = (status as IHashable).GetHash();

      foreach (var fault in HandleFaults(ef.Status, ef.NotObviatedFaults, ElectroFenceHub.UserIds))
        if (fault != null)
          ef.Log.Add(fault);

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
    public async Task<ActionResult<ElectroFenceForHwDto>> GetConfigAsync(string siteId)
    {
      var ef = await _repository.GetAsync(siteId);

      if (ef == null)
        return NotFound();

      return Ok(_mapper.Map<ElectroFenceForHwDto>(ef));
    }

    [HttpGet("id/{serial}")]
    public async Task<ActionResult<ElectroFenceForHwDto>> GetSiteIdAsync(string serial) =>
      Ok(new { Id = await _repository.GetSiteIdAsync(serial) });
  }
}