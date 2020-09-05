using System;
using System.Globalization;

namespace Dess.Helpers
{
  public class DessException : Exception
  {
    public DessException() : base() { }
    public DessException(string message) : base(message) { }
    public DessException(string message, params object[] args) : base(String.Format(CultureInfo.CurrentCulture, message, args)) { }
  }
}