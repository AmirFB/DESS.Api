namespace Dess.Api.Entities
{
  public class Input : Io
  {
    short Timer { get; set; }

    public override string GetHashBase()
    {
      var data = $"{Type}{Enabled}{Timer}";
      return data;
    }
  }
}