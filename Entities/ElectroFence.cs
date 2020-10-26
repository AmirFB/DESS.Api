﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

using Dess.Api.Models;

namespace Dess.Api.Entities
{
  public class ElectroFence : EntityBase, IHashable
  {
    [Required]
    public string Name { get; set; }

    [Required]
    public string SiteId { get; set; }

    [Required]
    public string SerialNo { get; set; }

    public string PhoneNumber { get; set; }
    public string Hash { get; set; }
    public bool Applied { get; set; }

    public bool UseGlobalInterval { get; set; }
    public byte Interval { get; set; }
    public byte Timeout { get; set; }

    public bool AutoLocation { get; set; }
    public string Latitude { get; set; }
    public string Longitude { get; set; }

    [Required]
    public bool HvEnabled { get; set; }

    [Required]
    public bool LvEnabled { get; set; }

    [Required]
    public bool TamperEnabled { set; get; }

    [Required]
    public byte HvPower { get; set; }

    [Required]
    public short HvThreshold { get; set; }

    [Required]
    public byte HvRepeat { get; set; }

    public bool TemperatureWarning { get; set; }
    public sbyte TemperatureMin { get; set; }
    public sbyte TemperatureMax { get; set; }

    public bool BatteryWarning { get; set; }
    public byte BatteryMin { get; set; }

    public ElectroFenceStatus Status { get; set; }

    public IList<Input> Inputs { get; set; }
    public IList<Output> Outputs { get; set; }
    public ICollection<ElectroFenceFault> Log { get; set; } = new List<ElectroFenceFault>();
    [NotMapped]
    public ICollection<ElectroFenceFault> NotObviatedFaults => Log.Where(l => l.ObviatedOn.Year < 1000).ToList();
    [NotMapped]
    public ICollection<ElectroFenceFault> ObviatedFaults => Log.Where(l => l.ObviatedOn.Year > 1000 && l.ResetedOn.Year < 1000).ToList();
    [NotMapped]
    public ICollection<ElectroFenceFault> NotResetedFaults => Log.Where(l => l.ResetedOn.Year < 1000).ToList();

    public string GetHashBase()
    {
      var data = $"{HvEnabled}{LvEnabled}{HvPower}{HvThreshold}" +
        $"{HvRepeat}{Inputs[0].GetHashBase()}{Inputs[1].GetHashBase()}" +
        $"{Outputs[0].GetHashBase()}{Outputs[1].GetHashBase()}";
      return data;
    }
  }
}