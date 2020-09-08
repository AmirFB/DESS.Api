using Dess.Entities;

namespace Dess.Models.User
{
  public class UserDto
  {
    public int Id { get; set; }

    public string Username { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
  }
}