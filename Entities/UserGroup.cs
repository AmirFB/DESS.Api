using System.Collections.Generic;

namespace Dess.Entities
{
  public class UserGroup : EntityBase
  {
    public string Name { get; set; }

    public ICollection<User> Users { get; set; }
  }
}