using System.ComponentModel.DataAnnotations;

using Dess.Api.Models;
using Dess.Api.Types;

namespace Dess.Api.Entities
{
	public abstract class Io : EntityBase, IHashable
	{
		public string Name { get; set; }

		[Required]
		public IOType Type { get; set; } = IOType.NO;
		[Required]
		public bool Enabled { get; set; } = true;

		[Required]
		public int ModuleId { get; set; }
		public Site Module { get; set; }

		public abstract string GetHashBase();
	}
}