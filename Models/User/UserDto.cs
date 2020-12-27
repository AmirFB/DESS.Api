namespace Dess.Api.Models.User
{
  public class UserDto
  {
    public int Id { get; set; }

    public string Username { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public int GroupId { get; set; }

    public int[] PermissionIds { get; set; }
  }
}