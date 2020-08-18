using Dess.Api.Services;

namespace Dess.Api.Models
{
  public interface IHashable
  {
    string GetHashBase();
    public virtual string GetHash() => Cryptography.GetHashMD5(GetHashBase());
  }
}