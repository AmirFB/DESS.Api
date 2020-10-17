using System.Collections.Generic;

namespace Dess.Api.Models.ElectroFence
{
  public class ElectroFenceForHwDto
  {
    public bool HvEnabled { get; set; }
    public bool LvEnabled { get; set; }

    public int HvPower { get; set; }
    public int HvThreshold { get; set; }
    public int HvRepeat { get; set; }

    public IEnumerable<IoDto> Ios { get; set; }
  }
}