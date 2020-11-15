using System.Collections.Generic;

namespace Dess.Api.Models.Site
{
  public class SiteForHwDto
  {
    public string Hash { get; set; }
    public bool HvEnabled { get; set; }
    public bool LvEnabled { get; set; }
    public bool TamperEnabled { get; set; }

    public byte HvPower { get; set; }
    public short HvThreshold { get; set; }
    public byte HvRepeat { get; set; }

    public byte Interval { get; set; }

    public bool UseHttps { get; set; } = false;

    public IEnumerable<InputForHwDto> Inputs { get; set; }
    public IEnumerable<OutputForHwDto> Outputs { get; set; }
  }
}