using System;
using System.Security.Cryptography;
using System.Text;

namespace Dess.Api.Helpers
{
  public static class Cryptography
  {
    public static byte[] GetHashMD5(string input)
    {
      using (var hash = new MD5CryptoServiceProvider())
        return hash.ComputeHash(Encoding.ASCII.GetBytes(input));
    }

    public static string GetHashMD5String(string input)
    {
      using (var hash = new MD5CryptoServiceProvider())
        return Convert.ToBase64String(hash.ComputeHash(Encoding.ASCII.GetBytes(input)));
    }

    public static byte[] GetHashSHA512(string input)
    {
      using (var hash = new SHA512CryptoServiceProvider())
        return hash.ComputeHash(Encoding.ASCII.GetBytes(input));
    }

    public static string GetHashSHA512String(string input)
    {
      using (var hash = new SHA512CryptoServiceProvider())
        return Convert.ToBase64String(hash.ComputeHash(Encoding.ASCII.GetBytes(input)));
    }

    public static string GeneratePasswordHash(string password) =>
      BCrypt.Net.BCrypt.EnhancedHashPassword(password);

    public static bool VerifyPasswordHash(string password, string hash) =>
      BCrypt.Net.BCrypt.EnhancedVerify(password, hash);
  }
}