using AutoMapper;
using Dess.Entities;
using Dess.Models.User;

namespace Dess.Profiles
{
  public class UserProfile : Profile
  {
    public UserProfile()
    {
      CreateMap<User, UserDto>().ReverseMap();
      CreateMap<UserRegisterDto, User>();
      CreateMap<UserUpdateDto, User>();
    }
  }
}