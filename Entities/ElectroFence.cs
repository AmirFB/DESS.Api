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
    public byte Interval { get; set; }

    public bool AutoLocation { get; set; }
    public string Latitude { get; set; }
    public string Longitude { get; set; }

    [Required]
    public bool HvEnabled { get; set; }

    [Required]
    public bool LvEnabled { get; set; }

    [Required]
    public byte HvPower { get; set; }

    [Required]
    public short HvThreshold { get; set; }

    [Required]
    public byte HvRepeat { get; set; }

    public sbyte TemperatureMin { get; set; }
    public sbyte TemperatureMax { get; set; }

    public bool TamperEnabled { set; get; }

    public byte BatteryMin { get; set; }

    public ElectroFenceStatus Status { get; set; }

    public IList<Io> Inputs { get; set; }
    public IList<Io> Outputs { get; set; }
    public ICollection<ElectroFenceStatus> Log { get; set; } = new List<ElectroFenceStatus>();

    public string GetHashBase()
    {
      var data = $"{HvEnabled}{LvEnabled}{HvPower}{HvThreshold}"
        + $"{HvRepeat}{Inputs[0]}{Inputs[1]}{Outputs[2]}{Outputs[3]}";
      return data;
    }
  }
}