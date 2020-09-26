using AutoMapper;
using Dess.Entities;
using Dess.Models.User;

namespace Dess.Profiles
{
  public class UserProfile : Profile
  {
    public UserProfile()
    {
      CreateMap<UserRegisterDto, User>();
      CreateMap<UserUpdateDto, User>();
      CreateMap<UserPermission, UserPermissionDto>();

      CreateMap<UserGroupPermission, int>().ConvertUsing(gp => gp.PermissionId);

      CreateMap<User, UserDto>()
        .ForMember(d => d.PermissionIds, m => m.MapFrom(e => e.Group.UserGroupPermissions))
        .ForAllMembers(options => options
        .Condition((src, dest, srcMember) => srcMember != null));

      CreateMap<UserGroup, UserGroupDto>()
        .ForMember(
          d => d.PermissionIds,
          m => m.MapFrom(e => e.UserGroupPermissions))
        .ForAllMembers(options => options
        .Condition((src, dest, srcMember) => srcMember != null));
    }
  }
}