using Dess.Api.Services;

namespace Dess.Api.Models
{
  public abstract class Hashable : IHashable
  {
    public abstract string GetHashBase();
    
    public string GetHash() =>
      (this as IHashable).GetHash();
  }
}