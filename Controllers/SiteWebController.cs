﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using AutoMapper;

using Dess.Api.Entities;
using Dess.Api.Models;
using Dess.Api.Models.Filters;
using Dess.Api.Models.Site;
using Dess.Api.Repositories;

namespace Dess.Api.Controllers
{
  [ApiController]
  [Route("api/web/sites")]
  public class SiteWebController : ControllerBase
  {
    private readonly ISiteRepository _siteRepository;
    private readonly ISiteGroupRepository _siteGroupRepository;
    private readonly IUserRepository _userRepository;
    private readonly ILogRepository _logRepository;
    private readonly IMapper _mapper;

    public SiteWebController(
      ISiteRepository siteRepository,
      ISiteGroupRepository siteGroupRepository,
      IUserRepository userRepository,
      ILogRepository logRepository,
      IMapper mapper)
    {
      _siteRepository = siteRepository ??
        throw new ArgumentNullException(nameof(siteRepository));

      _siteGroupRepository = siteGroupRepository ??
        throw new ArgumentNullException(nameof(siteGroupRepository));

      _userRepository = userRepository ??
        throw new ArgumentNullException(nameof(siteRepository));

      _logRepository = logRepository ??
        throw new ArgumentNullException(nameof(logRepository));

      _mapper = mapper ??
        throw new ArgumentNullException(nameof(mapper));
    }

    [HttpGet("{id}", Name = "GetAsync")]
    public async Task<ActionResult<SiteDto>> GetAsync([FromRoute] int id)
    {
      if (!await _siteRepository.ExistsAsync(id))
        return NotFound();

      var site = await _siteRepository.GetAsync(id);
      return Ok(_mapper.Map<SiteDto>(site));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<SiteDto>>> GetAllAsync()
    {
      var sites = await _siteRepository.GetAllWithEverythingAsync();
      var dtos = _mapper.Map<IEnumerable<SiteDto>>(sites);

      return Ok(dtos);
    }

    [Authorize(Policy = "CanAddRemoveSites")]
    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] SiteDto site)
    {
      var siteRepo = _mapper.Map<Site>(site);
      _siteRepository.Add(siteRepo);
      siteRepo.Hash = (siteRepo as IHashable).GetHash();
      siteRepo.Status = new SiteStatus();
      await _siteRepository.SaveAsync();

      var siteToReturn = _mapper.Map<SiteDto>(siteRepo);

      return CreatedAtRoute("GetAsync",
        new { id = siteToReturn.Id },
        siteToReturn);
    }

    [Authorize(Policy = "CanEditSites")]
    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] SiteDto site)
    {
      var siteFromRepo = await _siteRepository.GetWithIoAsync(site.Id);
      _mapper.Map(site, siteFromRepo);
      siteFromRepo.Hash = (siteFromRepo as IHashable).GetHash();
      await _siteRepository.SaveAsync();

      return Ok();
    }

    [Authorize(Policy = "CanAddRemoveSites")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
      var siteForomRepo = await _siteRepository.GetAsync(id);

      if (siteForomRepo == null)
      {
        return NotFound();
      }

      _siteRepository.Remove(siteForomRepo);
      await _siteRepository.SaveAsync();

      return NoContent();
    }

    [HttpGet("groups")]
    public async Task<ActionResult<IEnumerable<SiteGroupDto>>> GetGroupsAsync()
    {
      var groups = await _siteGroupRepository.GetAllAsync();
      var dtos = _mapper.Map<IEnumerable<SiteGroupDto>>(groups);

      return Ok(dtos);
    }

    [Authorize(Policy = "CanHandleSiteGroups")]
    [HttpPost("groups")]
    public async Task<IActionResult> AddGroupAsync([FromBody] SiteGroupDto group)
    {
      var groupRepo = _mapper.Map<SiteGroup>(group);
      _siteGroupRepository.Add(groupRepo);
      await _siteGroupRepository.SaveAsync();

      var groupToReturn = _mapper.Map<SiteGroupDto>(groupRepo);

      return CreatedAtRoute("GetAsync",
        new { id = groupToReturn.Id },
        groupToReturn);
    }

    [Authorize(Policy = "CanHandleSiteGroups")]
    [HttpPut("groups")]
    public async Task<IActionResult> UpdateGroupAsync([FromBody] SiteGroupDto group)
    {
      var groupFromRepo = await _siteGroupRepository.GetAsync(group.Id);
      _mapper.Map(group, groupFromRepo);
      await _siteGroupRepository.SaveAsync();

      return Ok();
    }

    [Authorize(Policy = "CanHandleSiteGroups")]
    [HttpDelete("groups/{id}")]
    public async Task<IActionResult> DeleteGroupAsync(int id)
    {
      var groupForomRepo = await _siteGroupRepository.GetAsync(id);

      if (groupForomRepo == null)
        return NotFound();

      _siteGroupRepository.Remove(groupForomRepo);
      await _siteGroupRepository.SaveAsync();

      return NoContent();
    }

    [HttpGet("log_old")]
    public async Task<ActionResult<IEnumerable<SiteFaultDto>>> GetAllLogAsync()
    {
      var logs = (await _siteRepository.GetAllLogAsync()).ToList();
      var dtos = _mapper.Map<IList<SiteFaultDto>>(logs);
      var users = await _userRepository.GetAllAsync();

      for (int i = 0; i < dtos.Count(); i++)
      {
        if (logs[i].ResetedOn.Year > 1000)
        {
          var user = users.FirstOrDefault(u => u.Id == logs[i].ResetedBy);
          dtos[i].ResetedBy = $"{user.FirstName} {user.LastName}";
        }

        foreach (var id in logs[i].SeenBy)
        {
          var user = users.FirstOrDefault(u => u.Id == id);
          dtos[i].SeenBy.Add($"{user.FirstName} {user.LastName}");
        }
      }

      return Ok(dtos);
    }

    [HttpPost("log")]
    public async Task<ActionResult<IEnumerable<SiteFaultDto>>> GetLogAsync([FromBody] ReportFilterDto filter)
    {
      var logs = (await _logRepository.GetAsync(filter)).ToList();
      var dtos = _mapper.Map<IList<SiteFaultDto>>(logs);
      var users = await _userRepository.GetAllAsync();

      for (int i = 0; i < dtos.Count(); i++)
      {
        if (logs[i].ResetedOn.Year > 1000)
        {
          var user = users.FirstOrDefault(u => u.Id == logs[i].ResetedBy);
          dtos[i].ResetedBy = $"{user.FirstName} {user.LastName}";
        }

        foreach (var id in logs[i].SeenBy)
        {
          var user = users.FirstOrDefault(u => u.Id == id);
          dtos[i].SeenBy.Add($"{user.FirstName} {user.LastName}");
        }
      }

      return Ok(dtos);
    }

    [HttpGet("{id}/log")]
    public async Task<ActionResult<IEnumerable<SiteStatusDto>>> GetModuleLogAsync([FromRoute] int id)
    {
      var logs = await _siteRepository.GetLogAsync(id);
      var dtos = _mapper.Map<IEnumerable<SiteStatusDto>>(logs);

      return Ok(dtos);
    }

    [Authorize(Policy = "CanResetFaults")]
    [HttpPut("reset/{moduleId}/")]
    [HttpPut("reset/{moduleId}/{faultId}")]
    public async Task<ActionResult<IEnumerable<SiteFault>>> ResetFaultAsync([FromRoute] int moduleId, [FromRoute] int? faultId)
    {
      var site = await _siteRepository.GetWithLogAsync(moduleId);

      if (site == null)
        return NotFound();

      var faults = site.ObviatedFaults;

      if (faultId.HasValue)
      {
        var fault = faults.FirstOrDefault(f => f.Id == faultId);

        if (fault == null)
          return NotFound();

        fault.ResetedOn = DateTime.UtcNow;
        fault.ResetedBy = int.Parse(HttpContext.User.Identities.ToList() [0].Claims.ToList() [0].Value);
      }

      else
      {
        foreach (var fault in faults)
        {
          fault.ResetedOn = DateTime.UtcNow;
          fault.ResetedBy = int.Parse(HttpContext.User.Identities.ToList() [0].Claims.ToList() [0].Value);
        }
      }

      await _siteRepository.SaveAsync();
      return Ok(site.NotResetedFaults);
    }
  }
}