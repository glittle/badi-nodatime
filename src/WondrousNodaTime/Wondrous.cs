// Copyright 2017 Glen Little. All rights reserved.
// Use of this source code is governed by the Apache License 2.0,
// as found in the LICENSE.txt file.

using NodaTime;
using WondrousNodaTime.Utility;

namespace WondrousNodaTime
{
  /// <summary>
  /// 
  /// </summary>
  public static class Wondrous
  {
    internal const int AyyamiHaMonth = 0;

    internal const int DaysInMonth = 19;

    internal const int Month18 = 18;

    /// <summary>
    /// Create a <see cref="LocalDate"/> in the Wondrous calendar, treating 0
    /// as the month containing Ayyam-i-Ha.
    /// </summary>
    /// <param name="year">Year in the Wondrous calendar</param>
    /// <param name="month">Month (use 0 for Ayyam-i-Ha)</param>
    /// <param name="day">Day in month</param>
    public static LocalDate CreateDate(int year, int month, int day)
    {
      if (month == AyyamiHaMonth)
      {
        // Move Ayyam-i-Ha days to fall after the last day of month 18.
        month = Month18;
        day += DaysInMonth;
      }
      return new LocalDate(year, month, day, CalendarSystem.Wondrous);
    }

    /// <summary>
    /// Return the day of this month, treating Ayyam-i-Ha as a separate month.
    /// </summary>
    internal static int Day(LocalDate input)
    {
      Checks.EnsureIsWondrousCalendar(nameof(input), input);

      if (input.Month == Month18 &&
          input.Day > DaysInMonth)
      {
        return input.Day - DaysInMonth;
      }
      return input.Day;
    }

    /// <summary>
    /// Return the month of this date. If in Ayyam-i-Ha, returns 0.
    /// </summary>
    internal static int Month(LocalDate input)
    {
      Checks.EnsureIsWondrousCalendar(nameof(input), input);

      if (input.Month == Month18 &&
          input.Day > DaysInMonth)
      {
        return AyyamiHaMonth;
      }
      return input.Month;
    }

    internal static int Element(LocalDate input) {
      Checks.EnsureIsWondrousCalendar(nameof(input), input);
      return Element(input.Month());
    }
    /// <summary>
    /// Return the element of this Wondrous month or Ayyam-i-Ha.
    /// </summary>
    /// <param name="month"></param>
    /// <remarks>
    /// The Báb groups the 19 months of the year into four sections, named after the elements.
    /// 
    /// The name/description of these elements can be described as:
    /// 
    /// 1, 2, 3 - Fire
    /// 4, 5, 6, 7 - Air
    /// 8, 9,10,11,12,13 - Water
    /// 14,15,16,17,18,19 - Earth
    /// 
    /// See 'https://books.google.ca/books?id=XTfoaK15t64C&pg=PA394&lpg=PA394&dq=get+of+the+heart+nader+bab&source=bl&ots=vyF-pWLAr8&sig=ruiuoE48sGWWgaB_AFKcSfkHvqw&hl=en&sa=X&ei=hbp0VfGwIon6oQSTk4Mg&ved=0CDAQ6AEwAw#v=snippet&q=%22air%20of%20eternity%22&f=false'
    /// </remarks>
    /// <returns></returns>
    public static int Element(int month)
    {
      var element = 1;
      if (month >= 4 && month <= 7)
      {
        element = 2;
      }
      else if (month >= 8 && month <= 13)
      {
        element = 3;
      }
      else if (month >= 14 && month <= 19)
      {
        element = 4;
      }
      else if (month == 0)
      {
        element = 0;
      }
      return element;
    }
  }
}
