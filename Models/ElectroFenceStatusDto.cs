using System;
using Dess.Types;

namespace Dess.Models
{
  public class ElectroFenceStatusDto : IHashable
  {

    public bool HvAlarm { get; set; }
    public bool LvAlarm { get; set; }
    public bool TamperAlarm { get; set; }

    public bool MainPowerFault { get; set; }
    public bool HvPowerFault { get; set; }
    public bool HvChargeFault { get; set; }
    public bool HvDischargeFault { get; set; }

    public double HvVoltage { get; set; }
    public double Temperature { get; set; }
    public byte BatteryLevel { get; set; }
    public BatteryStatus BatteryStatus { get; set; }

    public bool Input1 { get; set; }
    public bool Input2 { get; set; }
    public bool Output1 { get; set; }
    public bool Output2 { get; set; }

    public string Latitude { get; set; }
    public string Longitude { get; set; }
    public byte SignalStrength { get; set; }

    public string GetHashBase()
    {
      var data = $"{HvAlarm}{LvAlarm}{TamperAlarm}" +
      $"{BatteryStatus}{MainPowerFault}{HvPowerFault}{HvChargeFault}" +
      $"{HvDischargeFault}{Input1}{Input2}{Output1}{Output2}";
      return data;
    }
  }
}