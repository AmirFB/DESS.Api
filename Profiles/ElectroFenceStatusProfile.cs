﻿using AutoMapper;

using Dess.Api.Entities;
using Dess.Api.Helpers;
using Dess.Api.Models.ElectroFence;

namespace Dess.Api.Profiles
{
  public class ElectroFenceStatusProfile : Profile
  {
    public ElectroFenceStatusProfile()
    {
      CreateMap<ElectroFenceStatus, ElectroFenceStatusFromHwDto>().ReverseMap();
      CreateMap<ElectroFenceStatusFromHwDto, ElectroFenceStatusDto>();
      CreateMap<ElectroFenceStatus, ElectroFenceStatusDto>()
        .ForMember(d => d.SiteId, o => o.MapFrom(e => e.ElectroFenceId))
        .ForMember(d => d.Date, o => o.MapFrom(e => e.Date.JavascriptDate()));
      CreateMap<ElectroFenceStatus, ElectroFenceStatus>()
        .ForMember(d => d.Id, o => o.Ignore())
        .ForMember(d => d.ElectroFenceId, o => o.Ignore());
    }
  }
}