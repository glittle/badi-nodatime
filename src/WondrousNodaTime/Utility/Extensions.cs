using System;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace WondrousNodaTime.Utility
{
  /// <summary>
  /// General extensions
  /// </summary>
  public static class Extensions
  {
    /// <summary>
    /// Very simple token replacement, with lazy evaluation
    /// </summary>
    /// <param name="input"></param>
    /// <param name="args"></param>
    /// <returns></returns>
    public static string ReplaceTokens(this string input, params Expression<Func<string, object>>[] args)
    {
      // better options?
      // - SmartFormat.NET
      // - IT2media.Extensions.String
      // - StringTokenFormatter 
      // None of the above support the same selection of frameworks that we support, so don't work

      // adapted from http://www.c-sharpcorner.com/UploadFile/e4ff85/string-replacement-with-named-string-placeholders/

      var values = args.ToDictionary(e => string.Format("{{{0}}}", e.Parameters[0].Name), e => e);

      var sb = new StringBuilder(input);
      foreach (var kvp in values)
      {
        string token = kvp.Key;

        if (input.Contains(token))
        {
          var e = kvp.Value;
          var value = e.Compile()(e.Parameters[0].Name);

          sb.Replace(token, value != null ? value.ToString() : token);
        }
      }

      return sb.ToString();
    }

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
