using System;
using System.Collections.Generic;

namespace Dess.Api.Models.ElectroFence
{
	public class ElectroFenceFaultDto
	{
		public DateTime OccuredOn { get; set; }
		public DateTime ObviatedOn { get; set; }
		public DateTime ResetedOn { get; set; }

		public string ResetedBy { get; set; }

		public ICollection<string> SeenBy { get; set; }
	}
}