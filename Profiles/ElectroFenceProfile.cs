using AutoMapper;
using Dess.Entities;
using Dess.Models.ElectroFence;

namespace Dess.Profiles
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