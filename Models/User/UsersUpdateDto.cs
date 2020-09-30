namespace Dess.Api.Models.User
{
  public class UserUpdateDto
  {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public int? GroupId { get; set; }

    public byte[] ImageData { get; set; }
  }
}