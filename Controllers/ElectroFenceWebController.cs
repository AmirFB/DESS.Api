using System;
using System.Collections.Generic;
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
    private readonly IMapper _mapper;

    public ElectroFenceWebController(IElectroFenceRepository electroFenceRepository, IMapper mapper)
    {
      _repository = electroFenceRepository ??
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
      var efs = await _repository.GetAllWithIoAsync();
      return Ok(_mapper.Map<IEnumerable<ElectroFenceDto>>(efs));
    }

    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] ElectroFenceDto ef)
    {
      var efRepo = _mapper.Map<ElectroFence>(ef);
      _repository.Add(efRepo);
      efRepo.Hash = (efRepo as IHashable).GetHash();
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

    [HttpGet("{id}/status")]
    public async Task<ActionResult<ElectroFenceStatusDto>> GetStatusAsync(int id)
    {
      var ef = await _repository.GetWithStatusAsync(id);

      if (ef == null)
        return NotFound();

      return Ok(_mapper.Map<ElectroFenceStatusDto>(ef.Status));
    }

    [HttpGet("log")]
    public async Task<ActionResult<IEnumerable<ElectroFenceStatusDto>>> GetAllLogAsync(int id)
    {
      var logs = await _repository.GetAllLogAsync();
      var dtos = _mapper.Map<IEnumerable<ElectroFenceStatusDto>>(logs);

      return Ok(dtos);
    }

    [HttpGet("{id}/log")]
    public async Task<ActionResult<IEnumerable<ElectroFenceStatusDto>>> GetModuleLogAsync(int id)
    {
      var logs = await _repository.GetLogAsync(id);
      var dtos = _mapper.Map<IEnumerable<ElectroFenceStatusDto>>(logs);

      return Ok(dtos);
    }
  }
}