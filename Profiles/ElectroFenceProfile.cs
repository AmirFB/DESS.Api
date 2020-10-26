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
        .ForMember(d => d.Faults, o => o.MapFrom(e => e.NotResetedFaults));
      CreateMap<ElectroFenceDto, ElectroFence>()
        .ForMember(d => d.Status, o => o.Ignore());
    }
  }
}