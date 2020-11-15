using AutoMapper;

using Dess.Api.Entities;
using Dess.Api.Helpers;
using Dess.Api.Models.Site;

namespace Dess.Api.Profiles
{
  public class SiteStatusProfile : Profile
  {
    public SiteStatusProfile()
    {
      CreateMap<SiteStatus, SiteStatusFromHwDto>().ReverseMap();
      CreateMap<SiteStatusFromHwDto, SiteStatusDto>();
      CreateMap<SiteFault, SiteFaultDto>()
        .ForMember(d => d.OccuredOn, o => o.MapFrom(e => e.OccuredOn.JavascriptDate()))
        .ForMember(d => d.ObviatedOn, o => o.MapFrom(e => e.ObviatedOn.JavascriptDate()))
        .ForMember(d => d.ResetedOn, o => o.MapFrom(e => e.ResetedOn.JavascriptDate()))
        .ForMember(d => d.ResetedBy, o => o.Ignore())
        .ForMember(d => d.SeenBy, o => o.Ignore())
        .ForMember(d => d.SiteId, o => o.MapFrom(e => e.SiteId));
      CreateMap<SiteStatus, SiteStatusDto>()
        .ForMember(d => d.SiteId, o => o.MapFrom(e => e.SiteId))
        .ForMember(d => d.Date, o => o.MapFrom(e => e.Date.JavascriptDate()));
      CreateMap<SiteStatus, SiteStatus>()
        .ForMember(d => d.Id, o => o.Ignore())
        .ForMember(d => d.SiteId, o => o.Ignore());
    }
  }
}