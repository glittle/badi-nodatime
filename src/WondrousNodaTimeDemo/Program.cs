using NodaTime;
using System;
using System.Linq;
using WondrousNodaTime;

namespace WondrousNodaTimeDemo
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine($"Today is {new WondrousDate().ToString()}");

      var d1 = LocalDate.FromDateTime(DateTime.Now);
      Console.WriteLine($"Today is {d1.ToString()}");
      var w1 = new WondrousDate(d1);
      Console.WriteLine($"Today is {w1.ToString()}");

      var w2 = new WondrousDate();
      var d2 = w2.DateTime;
      Console.WriteLine($"{w2} --> {d2}");

      var date3 = new WondrousDate(175, 1, 1);
      var gregorianDate2 = date3.PlusDays(-1).DateTime;
      Console.WriteLine("The day before Naw Rúz 175 is " + gregorianDate2.ToString("D"));

      var year174 = new WondrousYearInfo(174);
      var listing = year174.GetSpecialDays(SpecialDayType.HolyDay_WorkSuspended | SpecialDayType.FeastDay);
      Console.WriteLine($"There are {listing.Count} Feast and major Holy Days in 174.");

      var nawRuz = year174.GetSpecialDays(SpecialDayType.HolyDay_WorkSuspended, HolyDayCode.NawRuz).First();
      Console.WriteLine($"Naw Ruz was on {nawRuz.Date.ToString("{W} ({G})")}");

      var dt = new WondrousNodaTime.Utility.DateTemplateProcessor();
      var list = dt.AvailableTokens;
      list.ForEach(s=> Console.WriteLine($"<dt>{s}</dt><dd>{w2.ToString($"{{{s}}}")}</dd>"));
    }
  }
}
