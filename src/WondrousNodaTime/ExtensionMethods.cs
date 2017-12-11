using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WondrousNodaTime
{
  /// <summary>
  /// Extension methods for the Wondrous calendar
  /// </summary>
  public static class Extensions
  {
    public static string ToWondrousString(this LocalDate input, string format = "") {
      var year = input.Year;
      var month = Wondrous.Month(input);
      var day = Wondrous.Day(input);

      return $"{year}-{month}-{day}";
    }
  }
}
