using System.Collections.Generic;

namespace Dess.Api.Models.ElectroFence
{
  public class ElectroFenceForHwDto
  {
    public bool HvEnabled { get; set; }
    public bool LvEnabled { get; set; }

    public byte HvPower { get; set; }
    public short HvThreshold { get; set; }
    public byte HvRepeat { get; set; }

    public byte Interval { get; set; }

    public IEnumerable<InputForHwDto> Inputs { get; set; }
    public IEnumerable<OutputForHwDto> Outputs { get; set; }
  }
}