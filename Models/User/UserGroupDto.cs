using System.Collections.Generic;
using Dess.Entities;

namespace Dess.Models.User
{
  public class UserGroupDto
  {
    public int Id { get; set; }
    public string Title { get; set; }

    public ICollection<int> PermissionIds { get; set; } = new List<int>();
    public ICollection<UserDto> Users { get; set; } = new List<UserDto>();
  }
}