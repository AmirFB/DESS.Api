using AutoMapper;

using Dess.Api.Entities;
using Dess.Api.Models;

namespace Dess.Api.Profiles
{
	public class IOProfile : Profile
    {
        public IOProfile()
		{
			CreateMap<IO, IODto>();
		}
    }
}