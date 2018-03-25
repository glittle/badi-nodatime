using System;
using System.Linq;

namespace BadiNodaTime.Utility
{
  /// <summary>
  /// General extensions
  /// </summary>
  public static class Extensions
  {
    /// <summary>
    /// Return a string padded with 0 if less than 9.
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static string Pad00(this int input)
    {
      return input < 10 ? "0" + input : input.ToString();
    }
  }
}
