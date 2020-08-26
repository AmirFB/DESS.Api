using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Dess.Models;

namespace Dess.Entities
{
  public class ElectroFence : EntityBase, IHashable
  {
    [Required]
    public string Serial { get; set; }
    public string PhoneNumber { get; set; }
    public string Hash { get; set; }
    public bool Applied { get; set; }

    public bool AutoLocation { get; set; }
    public string Latitude{ get; set; }
    public string Longitude{ get; set; }

    [Required]
    public bool HvEnabled { get; set; }
    [Required]
    public bool LvEnabled { get; set; }

    [Required]
    public int HvPower { get; set; }
    [Required]
    public int HvThreshold { get; set; }
    [Required]
    public int HvRepeat { get; set; }

    public int TemperatureMin { get; set; }
    public int TemperatureMax { get; set; }

    public double BatteryMin { get; set; }
    public double BatteryMax { get; set; }

    [Required]
    public IO Input1, Input2, Output1, Output2;

    public ElectroFenceStatus Status { get; set; }

    public ICollection<ElectroFenceStatus> Log { get; set; }

    public string GetHashBase()
    {
      var data = $"{HvEnabled}{LvEnabled}{HvPower}{HvThreshold}" +
      $"{HvRepeat}{Input1}{Input2}{Output1}{Output2}";
      return data;
    }
  }
}