using System.Collections.Generic;

using Dess.Api.Types;

namespace Dess.Api.Models.Site
{
    public class OutputForHwDto
    {
        public IOType Type { get; set; }
        public bool Enabled { get; set; }
        public short ResetTime { get; set; }

        public ICollection<TriggerType> Triggers { get; set; }
    }
}