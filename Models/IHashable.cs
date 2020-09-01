using Dess.Helpers;
using Dess.Services;

namespace Dess.Models
{
  public interface IHashable
  {
    string GetHashBase();
    public virtual string GetHash() => Cryptography.GetHashMD5String(GetHashBase());
  }
}