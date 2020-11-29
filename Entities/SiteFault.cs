using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Dess.Api.Types;

namespace Dess.Api.Entities
{
	public class SiteFault : EntityBase
	{
		public FaultType Type { get; set; }
		public DateTime OccuredOn { get; set; }
		public DateTime ObviatedOn { get; set; }
		public DateTime ResetedOn { get; set; }

		public int ResetedBy { get; set; }

		[Required]
		public int SiteId { get; set; }
		public Site Site { get; set; }

		public ICollection<int> SeenBy { get; set; } = new List<int>();
	}
}