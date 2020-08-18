using AutoMapper;

using Dess.Api.Entities;
using Dess.Api.Models;

namespace Dess.Api.Profiles
{
	public class ElectroFenceStatusProfile : Profile
    {
        public ElectroFenceStatusProfile()
        {
            CreateMap<ElectroFenceStatus, ElectroFenceStatusDto>().ReverseMap();
        }
    }
}
