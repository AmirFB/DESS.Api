using Dess.Types;

namespace Dess.Models.ElectroFence
{
  public class ElectroFenceStatusDto
  {
    public int Id { get; set; }

    public bool HvAlarm { get; set; }
    public bool LvAlarm { get; set; }
    public bool TamperAlarm { get; set; }

    public bool MainPowerFault { get; set; }
    public bool HvPowerFault { get; set; }
    public bool HvChargeFault { get; set; }
    public bool HvDischargeFault { get; set; }

    public double HvVoltage { get; set; }
    public double Temperature { get; set; }
    public BatteryStatus BatteryStatus { get; set; }
    public byte BatteryLevel { get; set; }

    public bool Input1 { get; set; }
    public bool Input2 { get; set; }
    public bool Output1 { get; set; }
    public bool Output2 { get; set; }

    public string Latitude { get; set; }
    public string Longitude { get; set; }
    public byte SignalStrength { get; set; }
  }
}