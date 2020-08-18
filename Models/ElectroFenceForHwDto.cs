using Dess.Api.Entities;

namespace Dess.Api.Models
{
  public class ElectroFenceForHwDto : EntityBase
  {
    public bool HvEnabled { get; set; }
    public bool LvEnabled { get; set; }

    public int HvPower { get; set; }
    public int HvThreshold { get; set; }
    public int HvRepeat { get; set; }

    public IO Input1, Input2, Output1, Output2;
  }
}