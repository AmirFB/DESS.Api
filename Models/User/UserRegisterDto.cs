using System.ComponentModel.DataAnnotations;

namespace Dess.Api.Models.User
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
    [Required]
    public int GroupId { get; set; }

    public byte[] ImageData { get; set; }
  }
}