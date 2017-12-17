using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using WondrousNodaTime.Resources;

namespace WondrousNodaTime.Utility
{
  internal class Formatter
  {
    WondrousResources _resolver = new WondrousResources();

    public string DateFormat(WondrousDate d, string patternText, IFormatProvider formatProvider)
    {
      var g = d.WithCalendar(CalendarSystem.Gregorian);

      if (string.IsNullOrWhiteSpace(patternText)){
        patternText = "W";
      }

      return patternText.ReplaceTokens(
        W => $"{d.YearOfEra}-{d.Month}-{d.Day}",
        G => $"{g.Year}-{g.Month}-{g.Day}",
        year_OfEra => d.YearOfEra,
        year_OfUnity => d.YearOfUnity,
        day => d.Day,
        day_Num00 => d.Day.Pad00(),
        day_Meaning => _resolver.GetListItem("MonthMeaning", d.Day),
        day_Arabic => _resolver.GetListItem("MonthArabic", d.Day),
        month => d.Month,
        month_Meaning => _resolver.GetListItem("MonthMeaning", d.Month),
        month_Arabic => _resolver.GetListItem("MonthArabic", d.Month)
      );
    }


  }
}
