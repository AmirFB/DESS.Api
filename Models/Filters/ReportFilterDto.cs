using System.Collections.Generic;

using Dess.Api.Types;

namespace Dess.Api.Models.Filters
{
	public class ReportFilterDto
	{
		public long? From { get; set; }
		public long? To { get; set; }

		public ReportType Type { get; set; }

		public bool AllGroups { get; set; }
		public bool AllSites { get; set; }
		public bool SeenByAll { get; set; }
		public bool ResetedByAll { get; set; }

		public IEnumerable<int> SiteGroupIds { get; set; } = new List<int>();
		public IEnumerable<int> SiteIds { get; set; } = new List<int>();

		public IEnumerable<FaultType> FaultTypes { get; set; }

		public IEnumerable<int> SeenBy { get; set; }
		public IEnumerable<int> ResetedBy { get; set; }
	}
}