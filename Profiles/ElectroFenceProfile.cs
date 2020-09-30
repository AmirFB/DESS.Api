using System.Collections.Generic;
using AutoMapper;
using Dess.Api.Entities;
using Dess.Api.Models.ElectroFence;

namespace Dess.Api.Profiles
{
  public class ElectroFenceProfile : Profile
  {
    public ElectroFenceProfile()
    {
      CreateMap<ElectroFence, ElectroFenceForHwDto>();

      CreateMap<ElectroFence, ElectroFenceDto>()
        .ForMember(d => d.Input1, o => o.MapFrom(e => e.IOs[0]))
        .ForMember(d => d.Input2, o => o.MapFrom(e => e.IOs[1]))
        .ForMember(d => d.Output1, o => o.MapFrom(e => e.IOs[2]))
        .ForMember(d => d.Output2, o => o.MapFrom(e => e.IOs[3]));

      CreateMap<ElectroFenceDto, ElectroFence>()
        .ForMember(e => e.IOs, o => o
        .MapFrom(d => new List<IODto> { d.Input1, d.Input2, d.Output1, d.Output2 }));
    }
  }
}