using System.Collections.Generic;

using Dess.Api.Types;

namespace Dess.Api.Models.Site
{
	public class SiteFaultDto
	{
		public FaultType Type { get; set; }

		public int Id { get; set; }
		public long OccuredOn { get; set; }
		public long ObviatedOn { get; set; }
		public long ResetedOn { get; set; }

		public string ResetedBy { get; set; }
		public int SiteId { get; set; }

		public ICollection<string> SeenBy { get; set; } = new List<string>();
	}
}