using System.ComponentModel.DataAnnotations;

using Dess.Api.Types;

namespace Dess.Api.Entities
{
  public class IO : EntityBase
  {
    public IOType Type { get; set; } = IOType.NO;
    public bool Enabled { get; set; } = true;

    [Required]
    public int ModuleId { get; set; }
    public ElectroFence Module { get; set; }

    public string GetHashBase()
    {
      var data = $"{Type}{Enabled}";
      return data;
    }
  }
}