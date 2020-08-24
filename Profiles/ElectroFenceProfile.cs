using AutoMapper;

using Dess.Api.Entities;
using Dess.Api.Models;

namespace Dess.Api.Profiles
{
  public class ElectroFenceProfile : Profile
  {
    public ElectroFenceProfile()
    {
      CreateMap<ElectroFence, ElectroFenceDto>().ReverseMap();
      CreateMap<ElectroFence, ElectroFenceForHwDto>();
    }
  }
}