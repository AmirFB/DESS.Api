using System.Collections.Generic;

namespace Dess.Api.Models.Site
{
  public class SiteDto
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string SiteId { get; set; }
    public string SerialNo { get; set; }

    public string PhoneNumber { get; set; }

    public bool UseGlobalInterval { get; set; }
    public byte Interval { get; set; }
    public byte Timeout { get; set; }

    public bool AutoLocation { get; set; }
    public string Latitude { get; set; }
    public string Longitude { get; set; }

    public bool HvEnabled { get; set; }
    public bool LvEnabled { get; set; }
    public bool TamperEnabled { get; set; }

    public byte HvPower { get; set; }
    public short HvThreshold { get; set; }
    public byte HvRepeat { get; set; }

    public bool TemperatureWarning { get; set; }
    public sbyte TemperatureMin { get; set; }
    public sbyte TemperatureMax { get; set; }

    public bool BatteryWarning { get; set; }
    public byte BatteryMin { get; set; }

    public int GroupId { get; set; }

    public SiteStatusDto Status { get; set; } = new SiteStatusDto();

    public ICollection<InputDto> Inputs { get; set; }
    public ICollection<OutputDto> Outputs { get; set; }
    public ICollection<SiteFaultDto> Faults { get; set; }
  }
}