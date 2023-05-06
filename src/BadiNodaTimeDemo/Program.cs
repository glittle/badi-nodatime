using NodaTime;
using System;
using System.Linq;
using System.Collections.Generic;
using BadiNodaTime;
using BadiNodaTime.Resources;
using System.Security.Cryptography.X509Certificates;

namespace BadiNodaTimeDemo
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine($"Today is {new BadiDate().ToString()}");

      var d1 = LocalDate.FromDateTime(DateTime.Now);
      Console.WriteLine($"Today is {d1.ToString()}");
      var w1 = new BadiDate(d1);
      Console.WriteLine($"Today is {w1.ToString()}");

      var w2 = new BadiDate();
      var d2 = w2.DateTime;
      Console.WriteLine($"{w2} --> {d2}");

      var date3 = new BadiDate(175, 1, 1);
      var gregorianDate2 = date3.PlusDays(-1).DateTime;
      Console.WriteLine("The day before Naw Rúz 175 is " + gregorianDate2.ToString("D"));

      var year174 = new BadiYearInfo(174);
      var listing = year174.GetSpecialDays(SpecialDayType.HolyDay_WorkSuspended | SpecialDayType.FeastDay);
      Console.WriteLine($"There are {listing.Count} Feast and major Holy Days in 174.");

      var nawRuz = year174.GetSpecialDays(SpecialDayType.HolyDay_WorkSuspended, HolyDayCode.NawRuz).First();
      Console.WriteLine($"Naw Ruz was on {nawRuz.Date.ToString()}");


      var dtp = new BadiNodaTime.Utility.DateTemplateProcessor();
      dtp.AvailableTokens(w2).ToList().ForEach(Console.WriteLine);

      Console.WriteLine("\nGerman...");
      var resolver = new BadiResources("de");
      dtp = new BadiNodaTime.Utility.DateTemplateProcessor(resolver);
      dtp.AvailableTokens(w2).ToList().ForEach(Console.WriteLine);

      UserInputDemo.SelectionDemo selectionDemo = new UserInputDemo.SelectionDemo();
      selectionDemo.StartSelection();
    }
  }
}