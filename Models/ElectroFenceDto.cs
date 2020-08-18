using Dess.Api.Entities;

namespace Dess.Api.Models
{
  public class ElectroFenceDto : EntityBase
  {
    public string Serial { get; set; }
    public string PhoneNumber { get; set; }
    public bool AutoLocation { get; set; }

    public bool HvEnabled { get; set; }
    public bool LvEnabled { get; set; }

    public int HvPower { get; set; }
    public int HvThreshold { get; set; }
    public int HvRepeat { get; set; }

    public IO Input1, Input2, Output1, Output2;
  }
}