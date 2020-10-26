using Dess.Api.Types;

namespace Dess.Api.Models.ElectroFence
{
    public class InputForHwDto
    {
        public short timer { get; set; }
        public IOType Type { get; set; }
        public bool Enabled { get; set; }
    }
}