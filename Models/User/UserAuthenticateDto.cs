using System.ComponentModel.DataAnnotations;

namespace Dess.Models.User
{
  public class UserAuthenticateDto
  {
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
  }
}