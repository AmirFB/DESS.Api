using System.Collections.Generic;

namespace Dess.Api.Entities
{
  public class UserGroup : EntityBase
  {
    public string Title { get; set; }

    public ICollection<UserGroupPermission> UserGroupPermissions { get; set; }
    public ICollection<User> Users { get; set; }
  }
}