using Dess.Api.Types;

namespace Dess.Api.Models.ElectroFence
{
  public class IODto
  {
    public int Id { get; set; }
    public string Name { get; set; }

    public IOType Type { get; set; }
    public bool Enabled { get; set; }
  }
}