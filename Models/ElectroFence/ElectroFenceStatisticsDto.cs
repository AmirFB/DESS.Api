using System.Collections.Generic;

namespace Dess.Api.Models.Site
{
    public abstract class SiteStatisticsDto
    {
        public string Hash { get; set; }

        public bool HvAlarm { get; set; }
        public bool LvAlarm { get; set; }
        public bool TamperAlarm { get; set; }

        public bool MainPowerFault { get; set; }
        public bool HvPowerFault { get; set; }
        public bool HvChargeFault { get; set; }
        public bool HvDischargeFault { get; set; }

        public IList<bool> Inputs { get; set; }
    }
}