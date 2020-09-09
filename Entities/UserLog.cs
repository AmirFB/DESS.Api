namespace Dess.Entities
{
  public class UserLog : EntityBase
  {
    public int UserId { get; set; }
    public User User { get; set; }

    public int LogId { get; set; }
    public ElectroFenceStatus Log { get; set; }
  }
}