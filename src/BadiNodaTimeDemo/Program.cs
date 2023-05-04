using NodaTime;
using System;
using System.Linq;
using System.Collections.Generic;
using BadiNodaTime;
using BadiNodaTime.Resources;

namespace BadiNodaTimeDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string closethis;
            do
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


                var specialDaysWantedList = new BadiYearInfo(174).GetSpecialDays(SpecialDayType.HolyDay_WorkSuspended, HolyDayCode.Ridvan1);
                Console.WriteLine($"specialDaysWantedList has {specialDaysWantedList.Count} item"); // Expected count of 1 item but was 9
                var firstDayOfRidvan = specialDaysWantedList.First();

                Console.WriteLine($"firstDayOfRidvan has code {firstDayOfRidvan.DayCode}"); // Expected code Ridvan1 but was Nawruz

                List<KeyValuePair<string, int>> myList = RetrieveEnumValues.GetEnumList<HolyDayCode>();
                foreach (var element in myList)
                {
                    Console.WriteLine(element.Value + " " + element.Key);
                }


                Console.WriteLine("x to close");
                closethis = Console.ReadLine();
            } while (closethis != "x");
            Console.WriteLine("Done!");
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
