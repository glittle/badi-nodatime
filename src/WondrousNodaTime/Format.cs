using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WondrousNodaTime.Utility;

namespace WondrousNodaTime
{
  internal class Formatter
  {
    internal static string ToWondrousString(LocalDate input, string format = "")
    {
      Checks.EnsureIsWondrousCalendar(nameof(input), input);

      var year = input.Year;
      var month = input.Month();
      var day = input.Day();

      return $"{year}-{month}-{day}";
    }
  }
}
