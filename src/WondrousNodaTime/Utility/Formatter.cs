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

      if (string.IsNullOrWhiteSpace(patternText))
      {
        patternText = "W";
      }

      return patternText.ReplaceTokens(
        W => $"{d.YearOfEra}-{d.Month}-{d.Day}",
        G => $"{g.Year}-{g.Month}-{g.Day}",

        day => d.Day,
        day00 => d.Day.Pad00(),
        day_ordinal => _resolver.GetListItem("OrdinalNames", d.Day),
        day_meaning => _resolver.GetListItem("MonthMeaning", d.Day),
        day_arabic => _resolver.GetListItem("MonthArabic", d.Day),

        weekday => d.Weekday,
        weekday00 => d.Weekday.Pad00(),
        weekday_ordinal => _resolver.GetListItem("OrdinalNames", d.Weekday),
        weekday_meaning => _resolver.GetListItem("WeekdayMeaning", d.Weekday),
        weekday_arabic => _resolver.GetListItem("WeekdayArabic", d.Weekday),

        month => d.Month,
        month00 => d.Month.Pad00(),
        month_ordinal => _resolver.GetListItem("OrdinalNames", d.Month),
        month_meaning => _resolver.GetListItem("MonthMeaning", d.Month),
        month_arabic => _resolver.GetListItem("MonthArabic", d.Month),

        element => d.Element,
        element00 => d.Element.Pad00(),
        element_meaning => _resolver.GetListItem("Elements", d.Element),

        yearOfEra => d.YearOfEra,
        yearOfEra00 => d.YearOfEra.Pad00(),

        yearOfUnity => d.YearOfUnity,
        yearOfUnity00 => d.YearOfUnity.Pad00(),
        yearOfUnity_ordinal => _resolver.GetListItem("OrdinalNames", d.YearOfUnity),
        yearOfUnity_meaning => _resolver.GetListItem("YearOfUnityMeaning", d.YearOfUnity),
        yearOfUnity_arabic => _resolver.GetListItem("YearOfUnityArabic", d.YearOfUnity),

        unity => d.Unity,
        unity00 => d.Unity.Pad00(),

        allThings => d.AllThings
      );
    }


  }
}
