using System.Collections.Generic;

using Dess.Api.Types;

namespace Dess.Api.Models.Site
{
  public class SiteStatusDto : SiteStatisticsDto
  {
    public long Date { get; set; }
    public string IpAddress { get; set; }
    public string SerialNo { get; set; }
    public bool Applied { get; set; }
    public int SiteId { get; set; }

    public short HvVoltage { get; set; }
    public short Temperature { get; set; }
    public BatteryStatus BatteryStatus { get; set; }
    public byte BatteryLevel { get; set; }

    public IList<bool> Outputs { get; set; }

    public string Latitude { get; set; }
    public string Longitude { get; set; }
    public byte SignalStrength { get; set; }
  }
}