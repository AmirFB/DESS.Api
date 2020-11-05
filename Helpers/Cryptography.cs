using System;
using System.Security.Cryptography;
using System.Text;

namespace Dess.Api.Helpers
{
  public static class Cryptography
  {
    public static byte[] GenerateHashMD5(string input)
    {
      using(var hash = new MD5CryptoServiceProvider())
      return hash.ComputeHash(Encoding.ASCII.GetBytes(input));
    }

    public static string GenerateHashMD5String(string input)
    {
      using(var hash = new MD5CryptoServiceProvider())
      return Convert.ToBase64String(hash.ComputeHash(Encoding.ASCII.GetBytes(input))).Replace("/", "_").Replace("+", "-");
    }

    public static byte[] GenerateHashSHA256(string input)
    {
      using(var hash = new SHA256CryptoServiceProvider())
      return hash.ComputeHash(Encoding.UTF8.GetBytes(input));
    }

    public static string GenerateHashSHA256String(string input)
    {
      using(var hash = new SHA256CryptoServiceProvider())
      return Convert.ToBase64String(hash.ComputeHash(Encoding.UTF8.GetBytes(input))).Replace("/", "_").Replace("+", "-");
    }

    public static byte[] GenerateHashSHA512(string input)
    {
      using(var hash = new SHA512CryptoServiceProvider())
      return hash.ComputeHash(Encoding.ASCII.GetBytes(input));
    }

    public static string GenerateHashSHA512String(string input)
    {
      using(var hash = new SHA512CryptoServiceProvider())
      return Convert.ToBase64String(hash.ComputeHash(Encoding.ASCII.GetBytes(input))).Replace("/", "_").Replace("+", "-");
    }

    public static string GeneratePasswordHash(string password) =>
      BCrypt.Net.BCrypt.EnhancedHashPassword(password);

    public static bool VerifyPasswordHash(string password, string hash) =>
      BCrypt.Net.BCrypt.EnhancedVerify(password, hash);
  }
}