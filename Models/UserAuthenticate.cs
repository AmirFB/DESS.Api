using System.ComponentModel.DataAnnotations;

namespace Dess.Models
{
  public class UserAuthenticate
  {
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
  }
}