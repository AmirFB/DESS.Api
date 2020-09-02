using AutoMapper;
using Dess.Entities;
using Dess.Models.ElectroFence;

namespace Dess.Profiles
{
  public class ElectroFenceStatusProfile : Profile
  {
    public ElectroFenceStatusProfile()
    {
      CreateMap<ElectroFenceStatus, ElectroFenceStatusDto>().ReverseMap();
    }
  }
}
