using System.ComponentModel.DataAnnotations;
using Dess.Models;
using Dess.Types;

namespace Dess.Entities
{
  public class IO : EntityBase, IHashable
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