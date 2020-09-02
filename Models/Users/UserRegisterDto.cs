using System.ComponentModel.DataAnnotations;

namespace Dess.Models.Users
{
  public class UserRegisterDto
  {
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
  }
}