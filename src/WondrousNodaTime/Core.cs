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
    public static int Day(LocalDate input)
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
    public static int Month(LocalDate input)
    {
      Checks.EnsureIsWondrousCalendar(nameof(input), input);

      if (input.Month == Month18 &&
          input.Day > DaysInMonth)
      {
        return AyyamiHaMonth;
      }
      return input.Month;
    }
  }
}
