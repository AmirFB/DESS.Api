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
        .ReverseMap()
        .ForMember(d => d.Status, o => o.Ignore());
    }
  }
}