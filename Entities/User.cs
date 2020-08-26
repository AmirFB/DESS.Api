namespace Dess.Entities
{
  public class User : EntityBase
  {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public byte[] PasswordSalt { get; set; }
    public byte[] PasswordHash { get; set; }
  }
}