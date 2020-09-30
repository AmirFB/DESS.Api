using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dess.Api.Entities
{
  public class User : EntityBase
  {
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }

    [Required]
    public int GroupId { get; set; }
    public UserGroup Group { get; set; }

    public ICollection<UserLog> UserLogs { get; set; }
  }
}