using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Dess.Api.Models;

namespace Dess.Api.Entities
{
  public class ElectroFence : EntityBase, IHashable
  {
    [Required]
    public string Name { get; set; }

    [Required]
    public string SiteId { get; set; }
    public string SerialNo { get; set; }

    [Required]
    public string Serial { get; set; }
    public string PhoneNumber { get; set; }
    public string Hash { get; set; }
    public bool Applied { get; set; }

    public bool UseGlobalIntervarl { get; set; }
    public int Interval { get; set; }

    public bool AutoLocation { get; set; }
    public string Latitude { get; set; }
    public string Longitude { get; set; }

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

    public ElectroFenceStatus Status { get; set; }

    public IList<Io> Ios { get; set; }
    public ICollection<ElectroFenceStatus> Log { get; set; } = new List<ElectroFenceStatus>();

    public string GetHashBase()
    {
      var data = $"{HvEnabled}{LvEnabled}{HvPower}{HvThreshold}" +
        $"{HvRepeat}{Ios[0]}{Ios[1]}{Ios[2]}{Ios[3]}";
      return data;
    }
  }
}