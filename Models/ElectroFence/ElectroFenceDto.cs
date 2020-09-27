using Dess.Entities;

namespace Dess.Models.ElectroFence
{
  public class ElectroFenceDto
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string SiteId { get; set; }
    public string SerialNo { get; set; }

    public string PhoneNumber { get; set; }
    public string IpAddress { get; set; }

    public bool UseGlobalIntervarl { get; set; }
    public int Interval { get; set; }

    public bool AutoLocation { get; set; }
    public string Latitude { get; set; }
    public string Longitude { get; set; }

    public bool HvEnabled { get; set; }
    public bool LvEnabled { get; set; }

    public int HvPower { get; set; }
    public int HvThreshold { get; set; }
    public int HvRepeat { get; set; }

    public int TemperatureMin { get; set; }
    public int TemperatureMax { get; set; }

    public double BatteryMin { get; set; }
    public double BatteryMax { get; set; }

    public IODto Input1 { get; set; }
    public IODto Input2 { get; set; }
    public IODto Output1 { get; set; }
    public IODto Output2 { get; set; }
  }
}