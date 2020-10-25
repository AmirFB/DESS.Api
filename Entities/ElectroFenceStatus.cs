using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Dess.Api.Models;
using Dess.Api.Types;

namespace Dess.Api.Entities
{
  public class ElectroFenceStatus : EntityBase, IHashable
  {
    public DateTime Date { get; set; }
    public string IpAddress { get; set; }
    public string SerialNo { get; set; }

    public string Hash { get; set; }

    public bool HvAlarm { get; set; }
    public bool LvAlarm { get; set; }
    public bool TamperAlarm { get; set; }

    public bool MainPowerFault { get; set; }
    public bool HvPowerFault { get; set; }
    public bool HvChargeFault { get; set; }
    public bool HvDischargeFault { get; set; }

    public short HvVoltage { get; set; }
    public short Temperature { get; set; }
    public BatteryStatus BatteryStatus { get; set; }
    public byte BatteryLevel { get; set; }

    public string Latitude { get; set; }
    public string Longitude { get; set; }
    public byte SignalStrength { get; set; }

    [Required]
    public int ElectroFenceId { get; set; }

    public IList<bool> Inputs { get; set; }
    public IList<bool> Outputs { get; set; }

    public string GetHashBase()
    {
      var data = $"{HvAlarm}{LvAlarm}{TamperAlarm}" +
        $"{BatteryStatus}{MainPowerFault}{HvPowerFault}{HvChargeFault}" +
        $"{HvDischargeFault}{Inputs[0]}{Inputs[1]}";
      return data;
    }
  }
}