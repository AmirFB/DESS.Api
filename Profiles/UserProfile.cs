using AutoMapper;
using Dess.Entities;
using Dess.Models.User;

namespace Dess.Profiles
{
  public class UserProfile : Profile
  {
    public UserProfile()
    {
      CreateMap<User, UserDto>()
        .ForAllMembers(options => options
        .Condition((src, dest, srcMember) => srcMember != null));
      CreateMap<UserRegisterDto, User>();
      CreateMap<UserUpdateDto, User>();
    }
  }
}