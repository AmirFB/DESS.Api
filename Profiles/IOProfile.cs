using AutoMapper;

using Dess.Api.Entities;
using Dess.Api.Models.ElectroFence;

namespace Dess.Api.Profiles
{
  public class IOProfile : Profile
  {
    public IOProfile()
    {
      CreateMap<Io, IoDto>().ReverseMap();
    }
  }
}