using Dess.Api.Entities;
using Dess.Api.Types;

namespace Dess.Api.Models
{
	public class IODto : EntityBase
    {
        public IOType Type { get; set; } = IOType.NO;
        public bool Enabled { get; set; } = true;
    }
}