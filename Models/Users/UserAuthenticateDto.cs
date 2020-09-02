using System.ComponentModel.DataAnnotations;

namespace Dess.Models.Users
{
  public class UserAuthenticateDto
  {
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
  }
}