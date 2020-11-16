using AutoMapper;

using Dess.Api.Entities;
using Dess.Api.Models.User;

namespace Dess.Api.Profiles
{
  public class UserProfile : Profile
  {
    public UserProfile()
    {
      CreateMap<UserRegisterDto, User>();
      CreateMap<UserUpdateDto, User>();
      CreateMap<Permission, PermissionDto>();

      CreateMap<User, UserDto>()
        .ForAllMembers(options => options
          .Condition((src, dest, srcMember) => srcMember != null));

      CreateMap<UserGroup, UserGroupDto>()
        .ForAllMembers(o => o
          .Condition((src, dest, srcMember) => srcMember != null));
    }
  }
}