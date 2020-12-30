using System.Collections.Generic;
using System.Linq;

using Dess.Api.Entities;
using Dess.Api.Types;

namespace Dess.Api.Helpers
{
	public class FaultString
	{
		private static string GetFaultString(Site site, SiteFault fault)
		{
			switch (fault.Type)
			{
				case FaultType.Hv:
					return "HV";

				case FaultType.Lv:
					return "LV";

				case FaultType.Input1:
					return site.Inputs[0].Name;

				case FaultType.Input2:
					return site.Inputs[1].Name;

				case FaultType.Power:
					return "برق";

				case FaultType.Tamper:
					return "جعبه";
			}

			return "ناشناس";
		}

		public static string GetFaultMessage(
			Site site,
			IEnumerable<SiteFault> raised,
			IEnumerable<SiteFault> obviated)
		{
			string message = "سایت " + site.Name + "\n";

			if (raised.Count() > 0)
			{
				message += "\n خطاهای رخ داده:";

				foreach (var fault in raised)
					message += "\n" + GetFaultString(site, fault);
			}

			if (obviated.Count() > 0)
			{
				if (raised.Count() > 0)
					message += "\n";

				message += "\n خطاهای رفع شده:";

				foreach (var fault in obviated)
					message += "\n" + GetFaultString(site, fault);
			}

			return message;
		}
	}
}