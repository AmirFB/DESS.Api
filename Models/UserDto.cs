using Dess.Entities;

namespace Dess.Models
{
  public class UserDto : EntityBase
  {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
  }
}