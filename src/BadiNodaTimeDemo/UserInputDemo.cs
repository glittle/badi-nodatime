using NodaTime;
using System;
using System.Linq;
using System.Collections.Generic;
using BadiNodaTime;
using BadiNodaTime.Resources;

namespace UserInputDemo
{
  class SelectionDemo
  {
    public int CaseSelect(string ChoseDemoTest)
    {
      int select = 0;
      bool loopMe = true;
      do
      {
        Console.WriteLine("\nChoose Demo");
        Console.WriteLine("1 for Holycode test\n2 for Enumarate info\n3 Default Demo\n4 Exit\n");
        ChoseDemoTest = null;
        while (true)
        {
          var key = System.Console.ReadKey(true);
          if (key.Key == ConsoleKey.Enter)
            break;
          ChoseDemoTest += key.KeyChar;
        }

        if (ChoseDemoTest == "1" || ChoseDemoTest == "2" || ChoseDemoTest == "3" || ChoseDemoTest == "4")
        {
          select = Convert.ToInt32(ChoseDemoTest);
          loopMe = false;
        }
      } while (loopMe);
      return select;
    }

    public void StartSelection()
    {
      string ChoseDemoTest = "";
      bool loopMe = true;
      Console.WriteLine("Welcome To Badi Noda Time Demo");
      do
      {
        int select = CaseSelect(ChoseDemoTest);
        switch (select)
        {
          case 1:
            Test01Holycode test01Holycode = new Test01Holycode();
            test01Holycode.RunTest();
            break;
          case 2:
            Test02Enumarate test02Enumarate = new Test02Enumarate();
            test02Enumarate.RunTest();
            break;
          case 3:
            DefultDemo defultDemo = new DefultDemo();
            defultDemo.RunTest();
            break;
          case 4:
            loopMe = false;
            break;
          default:
            break;
        }
      } while (loopMe);
    }
  }

  class DefultDemo
  {
    public void RunTest()
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
    }
  }

  class Test01Holycode
  {
    public void RunTest()
    {
      var specialDaysWantedList = new BadiYearInfo(174)
        .GetSpecialDays(SpecialDayType.HolyDay_WorkSuspended, HolyDayCode.Ridvan1);

      Console.WriteLine($"specialDaysWantedList has {specialDaysWantedList.Count} item");

      var firstDayOfRidvan = specialDaysWantedList.First();

      Console.WriteLine($"firstDayOfRidvan has code {firstDayOfRidvan.DayCode}");
      Console.WriteLine($"firstDayOfRidvan has code {firstDayOfRidvan.DayCode}");
      Console.WriteLine($"firstDayOfRidvan has code {firstDayOfRidvan.DayType}");
      Console.WriteLine($"firstDayOfRidvan has code {firstDayOfRidvan.Date}");
      Console.WriteLine($"firstDayOfRidvan has code {firstDayOfRidvan.TimeCode}");
    }
  }

  class Test02Enumarate
  {
    public void RunTest()
    {
      List<KeyValuePair<string, int>> myList = RetrieveEnumValues.GetEnumList<HolyDayCode>();
      foreach (var element in myList)
      {
        Console.WriteLine(element.Value + " " + element.Key);
      }
    }

    class RetrieveEnumValues
    {
      public static List<KeyValuePair<string, int>> GetEnumList<T>()
      {
        var list = new List<KeyValuePair<string, int>>();
        foreach (var e in Enum.GetValues(typeof(T)))
        {
          list.Add(new KeyValuePair<string, int>(e.ToString(), (int)e));
        }
        return list;
      }
    }
  }
}
