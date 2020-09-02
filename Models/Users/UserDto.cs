using Dess.Entities;

namespace Dess.Models.Users
{
  public class UserDto : EntityBase
  {
    public string Username { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
  }
}