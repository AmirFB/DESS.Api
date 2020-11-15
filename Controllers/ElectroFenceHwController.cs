using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

using AutoMapper;

using Dess.Api.Entities;
using Dess.Api.Helpers;
using Dess.Api.Hubs;
using Dess.Api.Models;
using Dess.Api.Models.Site;
using Dess.Api.Repositories;
using Dess.Api.Types;

namespace Dess.Api.Controllers
{
  [AllowAnonymous]
  [ApiController]
  [Route("api/hw")]
  public class SiteRepository : ControllerBase
  {
    private readonly ISiteRepository _repository;
    private readonly IUserLogRepository _userLogRepository;
    private readonly IMapper _mapper;
    private readonly IHubContext<SiteHub> _hubContext;

    public SiteRepository(ISiteRepository siteRepository, IUserLogRepository userLogRepository, IMapper mapper, IHubContext<SiteHub> hubContext)
    {
      _repository = siteRepository ??
        throw new ArgumentNullException(nameof(siteRepository));

      _userLogRepository = userLogRepository ??
        throw new ArgumentNullException(nameof(userLogRepository));

      _mapper = mapper ??
        throw new ArgumentNullException(nameof(mapper));

      _hubContext = hubContext ??
        throw new ArgumentNullException(nameof(_hubContext));
    }

    private SiteFault HandleHvFault(SiteStatus status, SiteFault fault, IEnumerable<int> users)
    {
      if (fault == null && status.HvAlarm)
      {
        var output = new SiteFault { SiteId = status.SiteId };
        output.OccuredOn = DateTime.UtcNow;
        output.Type = FaultType.Hv;
        foreach (var user in users)output.SeenBy.Add(user);
        return output;
      }

      if (fault != null && !status.HvAlarm)
        fault.ObviatedOn = DateTime.UtcNow;

      return null;
    }

    private SiteFault HandleLvFault(SiteStatus status, SiteFault fault, IEnumerable<int> users)
    {
      if (fault == null && status.LvAlarm)
      {
        var output = new SiteFault { SiteId = status.SiteId };
        output.OccuredOn = DateTime.UtcNow;
        output.Type = FaultType.Lv;
        foreach (var user in users)output.SeenBy.Add(user);
        return output;
      }

      if (fault != null && !status.LvAlarm)
        fault.ObviatedOn = DateTime.UtcNow;

      return null;
    }

    private SiteFault HandleTamperFault(SiteStatus status, SiteFault fault, IEnumerable<int> users)
    {
      if (fault == null && status.TamperAlarm)
      {
        var output = new SiteFault { SiteId = status.SiteId };
        output.OccuredOn = DateTime.UtcNow;
        output.Type = FaultType.Tamper;
        foreach (var user in users)output.SeenBy.Add(user);
        return output;
      }

      if (fault != null && !status.TamperAlarm)
        fault.ObviatedOn = DateTime.UtcNow;

      return null;
    }

    private SiteFault HandlePowerFault(SiteStatus status, SiteFault fault, IEnumerable<int> users)
    {
      if (fault == null && status.MainPowerFault)
      {
        var output = new SiteFault { SiteId = status.SiteId };
        output.OccuredOn = DateTime.UtcNow;
        output.Type = FaultType.Power;
        foreach (var user in users)output.SeenBy.Add(user);
        return output;
      }

      if (fault != null && !status.MainPowerFault)
        fault.ObviatedOn = DateTime.UtcNow;

      return null;
    }

    private SiteFault HandleInput1Fault(SiteStatus status, SiteFault fault, IEnumerable<int> users)
    {
      if (fault == null && status.Inputs[0])
      {
        var output = new SiteFault { SiteId = status.SiteId };
        output.OccuredOn = DateTime.UtcNow;
        output.Type = FaultType.Input1;
        foreach (var user in users)output.SeenBy.Add(user);
        return output;
      }

      if (fault != null && !status.Inputs[0])
        fault.ObviatedOn = DateTime.UtcNow;

      return null;
    }

    private SiteFault HandleInput2Fault(SiteStatus status, SiteFault fault, IEnumerable<int> users)
    {
      if (fault == null && status.Inputs[1])
      {
        var output = new SiteFault { SiteId = status.SiteId };
        output.OccuredOn = DateTime.UtcNow;
        output.Type = FaultType.Input2;
        foreach (var user in users)output.SeenBy.Add(user);
        return output;
      }

      if (fault != null && !status.Inputs[1])
        fault.ObviatedOn = DateTime.UtcNow;

      return null;
    }

    private IEnumerable<SiteFault> HandleFaults(SiteStatus status, IEnumerable<SiteFault> faults, IEnumerable<int> users)
    {
      yield return HandleHvFault(status, faults.FirstOrDefault(f => f.Type == FaultType.Hv), users);
      yield return HandleLvFault(status, faults.FirstOrDefault(f => f.Type == FaultType.Lv), users);
      yield return HandleTamperFault(status, faults.FirstOrDefault(f => f.Type == FaultType.Tamper), users);
      yield return HandlePowerFault(status, faults.FirstOrDefault(f => f.Type == FaultType.Power), users);
      yield return HandleInput1Fault(status, faults.FirstOrDefault(f => f.Type == FaultType.Input1), users);
      yield return HandleInput2Fault(status, faults.FirstOrDefault(f => f.Type == FaultType.Input2), users);
    }

    [HttpPost("{siteId}/{configHash}")]
    public async Task<IActionResult> UpdateAsync(string siteId, string configHash, [FromBody] SiteStatusFromHwDto status)
    {
      var site = await _repository.GetAsync(siteId);

      if (site == null)
        return BadRequest();

      var statusDto = _mapper.Map<SiteStatusDto>(status);
      statusDto.IpAddress = HttpContext.Connection.RemoteIpAddress.ToString();
      statusDto.SiteId = site.Id;
      statusDto.Date = DateTime.UtcNow.JavascriptDate();
      await _hubContext.Clients.All.SendAsync("UpdateStatus", statusDto);

      _mapper.Map(status, site.Status);
      site.Status.IpAddress = HttpContext.Connection.RemoteIpAddress.ToString();
      site.Status.Date = DateTime.UtcNow;
      site.Applied = configHash == site.Hash;

      var statusHash = (status as IHashable).GetHash();

      foreach (var fault in HandleFaults(site.Status, site.NotObviatedFaults, SiteHub.UserIds))
        if (fault != null)
          site.Log.Add(fault);

      if (site.AutoLocation)
      {
        site.Latitude = status.Latitude;
        site.Longitude = status.Longitude;
      }

      await _repository.SaveAsync();

      if (site.Applied)
        return NoContent();

      return Ok(_mapper.Map<SiteForHwDto>(site));
    }

    [HttpGet("{siteId}")]
    public async Task<ActionResult<SiteForHwDto>> GetConfigAsync(string siteId)
    {
      var site = await _repository.GetAsync(siteId);

      if (site == null)
        return NotFound();

      return Ok(_mapper.Map<SiteForHwDto>(site));
    }

    [HttpGet("id/{serial}")]
    public async Task<ActionResult<SiteForHwDto>> GetSiteIdAsync(string serial) =>
      Ok(new { Id = await _repository.GetSiteIdAsync(serial) });
  }
}