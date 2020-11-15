using AutoMapper;

using Dess.Api.Entities;
using Dess.Api.Models.Site;

namespace Dess.Api.Profiles
{
  public class IOProfile : Profile
  {
    public IOProfile()
    {
      CreateMap<Input, InputDto>().ReverseMap();
      CreateMap<Output, OutputDto>().ReverseMap();
      CreateMap<Input, InputForHwDto>();
      CreateMap<Output, OutputForHwDto>();
    }
  }
}