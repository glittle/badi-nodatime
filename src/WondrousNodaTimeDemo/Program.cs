using System;
using System.Linq;
using WondrousNodaTime;

namespace WondrousNodaTimeDemo
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine($"Today is {new WondrousDate().ToString("{W} ({G})")}");

      var yi = new WondrousYearInfo(174);
      var nawRuz = yi.GetSpecialDays(SpecialDayType.HolyDay_WorkSuspended, HolyDayCode.NawRuz).First();

      Console.WriteLine($"Naw Ruz was on {nawRuz.Date.ToString("{W} ({G})")}");
    }
  }
}
