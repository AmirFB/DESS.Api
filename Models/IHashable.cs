using Dess.Api.Helpers;

namespace Dess.Api.Models
{
  public interface IHashable
  {
    string GetHashBase();
    public virtual string GetHash() => Cryptography.GenerateHashMD5String(GetHashBase());
  }
}