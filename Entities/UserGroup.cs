using System.Collections.Generic;

namespace Dess.Api.Entities
{
  public class UserGroup : EntityBase
  {
    public string Title { get; set; }

    public ICollection<int> PermissionIds { get; set; } = new List<int>();
    public ICollection<User> Users { get; set; }
  }
}