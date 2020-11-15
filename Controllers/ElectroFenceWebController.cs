using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using AutoMapper;

using Dess.Api.Entities;
using Dess.Api.Models;
using Dess.Api.Models.Site;
using Dess.Api.Repositories;

namespace Dess.Api.Controllers
{
  [ApiController]
  [Route("api/web/sites")]
  public class SiteWebController : ControllerBase
  {
    private readonly ISiteRepository _repository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public SiteWebController(ISiteRepository siteRepository, IUserRepository userRepository, IMapper mapper)
    {
      _repository = siteRepository ??
        throw new ArgumentNullException(nameof(siteRepository));

      _userRepository = userRepository ??
        throw new ArgumentNullException(nameof(siteRepository));

      _mapper = mapper ??
        throw new ArgumentNullException(nameof(mapper));
    }

    [HttpGet("{id}", Name = "GetAsync")]
    public async Task<ActionResult<SiteDto>> GetAsync([FromRoute] int id)
    {
      if (!await _repository.ExistsAsync(id))
        return NotFound();

      var site = await _repository.GetAsync(id);
      return Ok(_mapper.Map<SiteDto>(site));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<SiteDto>>> GetAllAsync()
    {
      var sites = await _repository.GetAllWithEverythingAsync();
      var dtos = _mapper.Map<IEnumerable<SiteDto>>(sites);

      return Ok(dtos);
    }

    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] SiteDto site)
    {
      var siteRepo = _mapper.Map<Site>(site);
      _repository.Add(siteRepo);
      siteRepo.Hash = (siteRepo as IHashable).GetHash();
      siteRepo.Status = new SiteStatus();
      await _repository.SaveAsync();

      var siteToReturn = _mapper.Map<SiteDto>(siteRepo);

      return CreatedAtRoute("GetAsync",
        new { id = siteToReturn.Id },
        siteToReturn);
    }

    [Authorize(Policy = "CanEditSites")]
    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] SiteDto site)
    {
      var siteFromRepo = await _repository.GetWithIoAsync(site.Id);
      _mapper.Map(site, siteFromRepo);
      siteFromRepo.Hash = (siteFromRepo as IHashable).GetHash();
      await _repository.SaveAsync();

      return Ok();
    }

    [Authorize(Policy = "CanEditSites")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
      var siteForomRepo = await _repository.GetAsync(id);

      if (siteForomRepo == null)
      {
        return NotFound();
      }

      _repository.Remove(siteForomRepo);
      await _repository.SaveAsync();

      return NoContent();
    }

    [HttpGet("log")]
    public async Task<ActionResult<IEnumerable<SiteFaultDto>>> GetAllLogAsync()
    {
      var logs = (await _repository.GetAllLogAsync()).ToList();
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

    [HttpGet(" { id } / log ")]
    public async Task<ActionResult<IEnumerable<SiteStatusDto>>> GetModuleLogAsync([FromRoute] int id)
    {
      var logs = await _repository.GetLogAsync(id);
      var dtos = _mapper.Map<IEnumerable<SiteStatusDto>>(logs);

      return Ok(dtos);
    }

    [Authorize(Policy = "CanResetFaults")]
    [HttpPut("reset/{moduleId}/")]
    [HttpPut("reset/{moduleId}/{faultId}")]
    public async Task<ActionResult<IEnumerable<SiteFault>>> ResetFaultAsync([FromRoute] int moduleId, [FromRoute] int? faultId)
    {
      var site = await _repository.GetWithLogAsync(moduleId);

      if (site == null)
        return NotFound();

      var faults = site.ObviatedFaults;

      if (faultId.HasValue)
      {
        var fault = faults.FirstOrDefault(f => f.Id == faultId);

        if (fault == null)
          return NotFound();

        fault.ResetedOn = DateTime.UtcNow;
        fault.ResetedBy = int.Parse(HttpContext.User.Identities.ToList()[0].Claims.ToList()[0].Value);
      }

      else
      {
        foreach (var fault in faults)
        {
          fault.ResetedOn = DateTime.UtcNow;
          fault.ResetedBy = int.Parse(HttpContext.User.Identities.ToList()[0].Claims.ToList()[0].Value);
        }
      }

      await _repository.SaveAsync();
      return Ok(site.NotResetedFaults);
    }
  }
}