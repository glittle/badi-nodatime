using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace WondrousNodaTime.Utility
{
  internal class Formatter
  {
    public string DateFormat(WondrousDate d, string patternText, IFormatProvider formatProvider)
    {
      var g = d.WithCalendar(CalendarSystem.Gregorian);

      if (string.IsNullOrWhiteSpace(patternText)){
        patternText = "W";
      }

      return patternText.ReplaceTokens(
        W => $"{d.YearOfEra}-{d.Month}-{d.Day}",
        G => $"{g.Year}-{g.Month}-{g.Day}"
      );
    }


  }
}
