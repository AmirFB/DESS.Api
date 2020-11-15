using Dess.Api.Types;

namespace Dess.Api.Models.Site
{
  public class IoDto
  {
    public int Id { get; set; }
    public string Name { get; set; }

    public IOType Type { get; set; }
    public bool Enabled { get; set; }
  }
}