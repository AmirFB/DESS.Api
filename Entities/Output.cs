using System.Collections.Generic;

using Dess.Api.Types;

namespace Dess.Api.Entities
{
  public class Output : Io
  {
    public short ResetTime { get; set; }

    public byte[] Triggers { get; set; }

    public override string GetHashBase()
    {
      var data = $"{Type}{Enabled}{ResetTime}";
      foreach (var trigger in Triggers)
        data += (int) trigger;
      return data;
    }
  }
}