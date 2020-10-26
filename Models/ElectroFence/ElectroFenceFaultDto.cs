using System.Collections.Generic;

using Dess.Api.Types;

namespace Dess.Api.Models.ElectroFence
{
	public class ElectroFenceFaultDto
	{
<<<<<<< HEAD
		public FaultType Type { get; set; }

=======
		public int Id { get; set; }
>>>>>>> e83f5834bfa36a1205e229763e1a1d5a95af2491
		public long OccuredOn { get; set; }
		public long ObviatedOn { get; set; }
		public long ResetedOn { get; set; }

		public string ResetedBy { get; set; }

		public ICollection<string> SeenBy { get; set; } = new List<string>();
	}
}