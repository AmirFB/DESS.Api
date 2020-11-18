using System.Collections.Generic;

using AutoMapper;

using Dess.Api.Entities;
using Dess.Api.Models.Site;

namespace Dess.Api.Profiles
{
  public class SiteProfile : Profile
  {
    public SiteProfile()
    {
      CreateMap<Site, SiteForHwDto>();
      CreateMap<Site, SiteDto>()
        .ForMember(d => d.Faults, o => o.MapFrom(e => e.NotResetedFaults));
      CreateMap<SiteDto, Site>()
        .ForMember(d => d.Status, o => o.Ignore());
      CreateMap<SiteGroup, SiteGroupDto>();
    }
  }
}