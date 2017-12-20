// Copyright 2017 Glen Little. All rights reserved.
// Use of this source code is governed by the Apache License 2.0,
// as found in the LICENSE.txt file.

using NodaTime;
using System;

namespace WondrousNodaTime
{
  public partial class WondrousDate 
  {
    internal const int AyyamiHaMonth = 0;

    internal const int DaysInMonth = 19;

    internal const int Month18 = 18;

    private readonly LocalDate _date;

    /// <summary>
    /// Create a Wondrous date with the current time
    /// </summary>
    public WondrousDate() : this(DateTime.Now)
    { }

    /// <summary>
    /// Create a Wondrous date from an existing <see cref="LocalDate"/> 
    /// </summary>
    /// <param name="date"></param>
    public WondrousDate(LocalDate date)
    {
      if (date.Calendar == CalendarSystem.Wondrous)
      {
        _date = date;
      }
      _date = date.WithCalendar(CalendarSystem.Wondrous);
    }


    /// <summary>
    /// Create a Wondrous date from a <see cref="DateTime"/> 
    /// </summary>
    /// <param name="dateTime">The date is used, ignoring the time of day.</param>
    public WondrousDate(DateTime dateTime)
    {
      var iso = new LocalDate(dateTime.Year, dateTime.Month, dateTime.Day);
      _date = iso.WithCalendar(CalendarSystem.Wondrous);
    }

    /// <summary>
    /// Create a Wondrous date, treating 0
    /// as the month containing Ayyam-i-Ha.
    /// </summary>
    /// <param name="year">Year in the Wondrous calendar</param>
    /// <param name="month">Month (use 0 for Ayyam-i-Ha)</param>
    /// <param name="day">Day in month</param>
    public WondrousDate(int year, int month, int day)
    {
      if (month == AyyamiHaMonth)
      {
        // Move Ayyam-i-Ha days to fall after the last day of month 18.
        month = Month18;
        day += DaysInMonth;
      }
      _date = new LocalDate(year, month, day, CalendarSystem.Wondrous);
    }

    /// <summary>
    /// The underlying <see cref="LocalDate"/> 
    /// </summary>
    public LocalDate LocalDate { get { return _date; } }

    /// <summary>
    /// The <see cref="DateTime"/> at midnight of the current date.
    /// </summary>
    public DateTime DateTime { get { return _date.WithCalendar(CalendarSystem.Iso).ToDateTimeUnspecified(); } }

    /// <summary>
    /// Convert to desired calendar
    /// </summary>
    /// <param name="calendar"><see cref="T:CalendarSystem"/></param>
    /// <returns></returns>
    public LocalDate WithCalendar(CalendarSystem calendar)
    {
      return _date.WithCalendar(calendar);
    }

    /// <summary>
    /// Return the day of this month, treating Ayyam-i-Ha as a separate month.
    /// </summary>
    public int Day
    {
      get
      {
        if (_date.Month == Month18 &&
            _date.Day > DaysInMonth)
        {
          return _date.Day - DaysInMonth;
        }
        return _date.Day;
      }
    }


    /// <summary>
    /// Return the month of this date. If in Ayyam-i-Ha, returns 0.
    /// </summary>
    public int Month
    {
      get
      {
        if (_date.Month == Month18 &&
            _date.Day > DaysInMonth)
        {
          return AyyamiHaMonth;
        }
        return _date.Month;
      }
    }

    /// <summary>
    /// Year of the Bahá'í Era
    /// </summary>
    public int YearOfEra
    {
      get
      {
        return _date.Year;
      }
    }

    /// <summary>
    /// Year of the Unity (Váḥid)
    /// </summary>
    public int YearOfUnity
    {
      get
      {
        return _date.Year - 19 * (Unity - 1);
      }
    }

    /// <summary>
    /// Unity (Váḥid)
    /// </summary>
    public int Unity
    {
      get
      {
        return (int)Math.Floor(1 + (_date.Year - 1) / 19D);
      }
    }

    /// <summary>
    /// AllThings (Kull-i-Shay’)
    /// </summary>
    public int AllThings
    {
      get
      {
        return (int)Math.Floor(1 + (_date.Year - 1) / (19D * 19D));
      }
    }


    /// <summary>
    /// Return the element of the year.
    /// </summary>
    /// <remarks>
    /// The Báb groups the 19 months of the year into four sections, named after the elements.
    /// 
    /// The name/description of these elements can be described as:
    /// 
    /// 1: 1, 2, 3 - Fire
    /// 2: 4, 5, 6, 7 - Air
    /// 3: 8, 9,10,11,12,13 - Water
    /// 4: 14,15,16,17,18,19 - Earth
    /// 
    /// See 'https://books.google.ca/books?id=XTfoaK15t64C&amp;pg=PA394&amp;lpg=PA394&amp;dq=get+of+the+heart+nader+bab&amp;source=bl&amp;ots=vyF-pWLAr8&amp;sig=ruiuoE48sGWWgaB_AFKcSfkHvqw&amp;hl=en&amp;sa=X&amp;ei=hbp0VfGwIon6oQSTk4Mg&amp;ved=0CDAQ6AEwAw#v=snippet&amp;q=%22air%20of%20eternity%22&amp;f=false'
    /// </remarks>
    /// <returns></returns>
    public int Element
    {
      get
      {
        var month = Month;
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

    /// <summary>
    /// Day of week, from 1 to 7. Day 1 is Saturday (started at sunset on Friday)
    /// </summary>
    public int Weekday
    {
      get
      {
        return 1 + ((int)_date.DayOfWeek + 1) % 7;
      }
    }
  }
}
