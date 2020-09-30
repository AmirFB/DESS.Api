using System;
using System.ComponentModel.DataAnnotations;

namespace Dess.Api.Models.User
{
  public class UserAuthenticateDto
  {
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }

    public TimeSpan? ValidTime { get; set; }
  }
}