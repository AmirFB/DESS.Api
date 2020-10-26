using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using AutoMapper;

using Dess.Api.Entities;
using Dess.Api.Models;
using Dess.Api.Models.ElectroFence;
using Dess.Api.Repositories;

namespace Dess.Api.Controllers
{
  [ApiController]
  [Route("api/web/efs")]
  public class ElectroFenceWebController : ControllerBase
  {
    private readonly IElectroFenceRepository _repository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public ElectroFenceWebController(IElectroFenceRepository electroFenceRepository, IUserRepository userRepository, IMapper mapper)
    {
      _repository = electroFenceRepository ??
        throw new ArgumentNullException(nameof(electroFenceRepository));

      _userRepository = userRepository ??
        throw new ArgumentNullException(nameof(electroFenceRepository));

      _mapper = mapper ??
        throw new ArgumentNullException(nameof(mapper));
    }

    [HttpGet("{id}", Name = "GetAsync")]
    public async Task<ActionResult<ElectroFenceDto>> GetAsync([FromRoute] int id)
    {
      if (!await _repository.ExistsAsync(id))
        return NotFound();

      var ef = await _repository.GetAsync(id);
      return Ok(_mapper.Map<ElectroFenceDto>(ef));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ElectroFenceDto>>> GetAllAsync()
    {
      var efs = await _repository.GetAllWithEverythingAsync();
      var dtos = _mapper.Map<IEnumerable<ElectroFenceDto>>(efs);

      return Ok(dtos);
    }

    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] ElectroFenceDto ef)
    {
      var efRepo = _mapper.Map<ElectroFence>(ef);
      _repository.Add(efRepo);
      efRepo.Hash = (efRepo as IHashable).GetHash();
      efRepo.Status = new ElectroFenceStatus();
      await _repository.SaveAsync();

      var electroFenceToReturn = _mapper.Map<ElectroFenceDto>(efRepo);

      return CreatedAtRoute("GetAsync",
        new { id = electroFenceToReturn.Id },
        electroFenceToReturn);
    }

    [Authorize(Policy = "CanEditSites")]
    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] ElectroFenceDto ef)
    {
      var efFromRepo = await _repository.GetWithIoAsync(ef.Id);
      _mapper.Map(ef, efFromRepo);
      efFromRepo.Hash = (efFromRepo as IHashable).GetHash();
      await _repository.SaveAsync();

      return Ok();
    }

    [Authorize(Policy = "CanEditSites")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
      var electroFenceForomRepo = await _repository.GetAsync(id);

      if (electroFenceForomRepo == null)
      {
        return NotFound();
      }

      _repository.Remove(electroFenceForomRepo);
      await _repository.SaveAsync();

      return NoContent();
    }

    [HttpGet("log")]
    public async Task<ActionResult<IEnumerable<ElectroFenceFaultDto>>> GetAllLogAsync()
    {
      var logs = (await _repository.GetAllLogAsync()).ToList();
      var dtos = _mapper.Map<IList<ElectroFenceFaultDto>>(logs);
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
    public async Task<ActionResult<IEnumerable<ElectroFenceStatusDto>>> GetModuleLogAsync([FromRoute] int id)
    {
      var logs = await _repository.GetLogAsync(id);
      var dtos = _mapper.Map<IEnumerable<ElectroFenceStatusDto>>(logs);

      return Ok(dtos);
    }

    [Authorize(Policy = "CanResetFaults")]
    [HttpPut("reset/{moduleId}/")]
    [HttpPut("reset/{moduleId}/{faultId}")]
    public async Task<ActionResult<IEnumerable<ElectroFenceFault>>> ResetFaultAsync([FromRoute] int moduleId, [FromRoute] int? faultId)
    {
      var ef = await _repository.GetWithLogAsync(moduleId);

      if (ef == null)
        return NotFound();

      var faults = ef.ObviatedFaults;

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
      return Ok(ef.NotResetedFaults);
    }
  }
}