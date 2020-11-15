using System.Collections.Generic;

using Dess.Api.Types;

namespace Dess.Api.Models.Site
{
  public class OutputDto : IoDto
  {
    public short ResetTime { get; set; }

    public ICollection<TriggerType> Triggers { get; set; }
  }
}