using System.Collections.Generic;

namespace Dess.Api.Models.ElectroFence
{
  public class ElectroFenceDto
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string SiteId { get; set; }
    public string SerialNo { get; set; }

    public string PhoneNumber { get; set; }

    public bool UseGlobalIntervarl { get; set; }
    public byte Interval { get; set; }

    public bool AutoLocation { get; set; }
    public string Latitude { get; set; }
    public string Longitude { get; set; }

    public bool HvEnabled { get; set; }
    public bool LvEnabled { get; set; }

    public byte HvPower { get; set; }
    public short HvThreshold { get; set; }
    public byte HvRepeat { get; set; }

    public sbyte TemperatureMin { get; set; }
    public sbyte TemperatureMax { get; set; }

    public bool TamperEnabled { get; set; }

    public byte BatteryMin { get; set; }

    public ElectroFenceStatusDto Status { get; set; }

    public IList<InputDto> Inputs { get; set; }
    public IList<OutputDto> Outputs { get; set; }
  }
}