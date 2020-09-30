using System.Collections.Generic;

namespace Dess.Api.Entities
{
  public class UserPermission : EntityBase
  {
    public string Title { get; set; }

    public ICollection<UserGroupPermission> UserGroupPermissions { get; set; }
  }
}