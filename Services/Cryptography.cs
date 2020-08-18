using System.Security.Cryptography;
using System.Text;
using Dess.Api.Entities;
using Dess.Api.Models;

namespace Dess.Api.Services
{
  public static class Cryptography
  {
    public static string GetHashMD5(string input)
    {
      using (var hash = new MD5CryptoServiceProvider())
      {
        return Encoding.ASCII.GetString(hash.ComputeHash(Encoding.ASCII.GetBytes(input)));
      }
    }
  }
}