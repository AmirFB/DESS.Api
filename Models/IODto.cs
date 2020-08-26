using Dess.Entities;
using Dess.Types;

namespace Dess.Models
{
	public class IODto : EntityBase
    {
        public IOType Type { get; set; } = IOType.NO;
        public bool Enabled { get; set; } = true;
    }
}