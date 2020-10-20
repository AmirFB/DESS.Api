using System.Collections.Generic;

using Dess.Api.Types;

namespace Dess.Api.Models.ElectroFence
{
  public class OutputDto : IoDto
  {
    public ICollection<TriggerType> Triggers { get; set; }
    public short ResetTime { get; set; }
  }
}