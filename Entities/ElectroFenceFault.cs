using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Dess.Api.Types;

namespace Dess.Api.Entities
{
	public class ElectroFenceFault : EntityBase
	{
		public FaultType Type { get; set; }
		public DateTime OccuredOn { get; set; }
		public DateTime ObviatedOn { get; set; }
		public DateTime ResetedOn { get; set; }

		public int ResetedBy { get; set; }

		[Required]
		public int ElectroFenceId { get; set; }

		public ICollection<int> SeenBy { get; set; }
	}
}