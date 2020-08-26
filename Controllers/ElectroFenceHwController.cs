using System;
using System.Threading.Tasks;
using AutoMapper;
using Dess.Models;
using Dess.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Dess.Controllers
{
  [ApiController]
  [Route("api/irancell/hw")]
  public class ElectroFenceRepository : ControllerBase
  {
    private readonly IElectroFenceRepository _repository;
    private readonly IMapper _mapper;

    public ElectroFenceRepository(IElectroFenceRepository electroFenceRepository, IMapper mapper)
    {
      _repository = electroFenceRepository ??
          throw new ArgumentNullException(nameof(electroFenceRepository));
      _mapper = mapper ??
          throw new ArgumentNullException(nameof(mapper));
    }

    [HttpPost("{serial}/{configHash}")]
    public async Task<IActionResult> UpdateAsync(string serial, string configHash, [FromBody] ElectroFenceStatusDto status)
    {
      var ef = await _repository.GetAsync(serial);

      if (ef == null)
        return NotFound();

      _mapper.Map(status, ef.Status);
      ef.Applied = configHash == ef.Hash;

      var statusHash = (status as IHashable).GetHash();

      if (ef.Status.Hash != statusHash)
      {
        ef.Status.Hash = statusHash;
        ef.Log.Add(ef.Status);
      }

      if(ef.AutoLocation)
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