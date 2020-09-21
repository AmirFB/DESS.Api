using System.ComponentModel.DataAnnotations;

namespace Dess.Entities
{
  public class UserGroupPermission
  {
    public int GroupId { get; set; }
    public UserGroup Group { get; set; }

    public int PermissionId { get; set; }
    public UserPermission Permission { get; set; }
  }
}