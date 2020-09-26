using AutoMapper;
using Dess.Entities;
using Dess.Models.ElectroFence;

namespace Dess.Profiles
{
  public class IOProfile : Profile
  {
    public IOProfile()
    {
      CreateMap<IO, IODto>();
    }
  }
}