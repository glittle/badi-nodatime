// Copyright 2017 Glen Little. All rights reserved.
// Use of this source code is governed by the Apache License 2.0,
// as found in the LICENSE.txt file.

using NodaTime;
using System;
using System.Collections.Generic;
using WondrousNodaTime.Utility;

namespace WondrousNodaTime
{
  /// <summary>
  /// Information about this year
  /// </summary>
  public class YearInfo
  {
    CalendarSystem _calendarSystem = CalendarSystem.Wondrous;
    int _year;

    /// <summary>
    /// Constructor for specific year
    /// </summary>
    /// <param name="year"></param>
    public YearInfo(int year)
    {
      Checks.CheckArgument(year >= _calendarSystem.MinYear && year <= _calendarSystem.MaxYear, nameof(year), "Year out of supported range");
      _year = year;
    }

    /// <summary>
    /// Is this year a longer year?
    /// </summary>
    public int DaysInAyyamiHa
    {
      get
      {
        return IsLeapYear ? 5 : 4;
      }
    }

    /// <summary>
    /// Is this year a longer year?
    /// </summary>
    public bool IsLeapYear
    {
      get
      {
        return _calendarSystem.IsLeapYear(_year);
      }
    }

    /// <summary>
    /// A listing of special days in this year
    /// </summary>
    public IEnumerable<SpecialDay> GetSpecialDays(SpecialDayEnum typesWanted)
    {
      {
        // TO DO...
        yield return new SpecialDay(new WondrousDate(_year, 1, 1), SpecialDayEnum.FeastDay);
      }
    }
  }
}
