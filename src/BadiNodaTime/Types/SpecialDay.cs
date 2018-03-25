// Copyright 2017 Glen Little. All rights reserved.
// Use of this source code is governed by the Apache License 2.0,
// as found in the LICENSE.txt file.

using System;

namespace BadiNodaTime
{
  /// <summary>
  /// A special day in the Bahá'í religious year
  /// </summary>
  public struct SpecialDay
  {
    /// <summary>
    /// Create a special day
    /// </summary>
    /// <param name="date"></param>
    /// <param name="dayType"></param>
    public SpecialDay(BadiDate date, SpecialDayType dayType) : this()
    {
      Date = date;
      DayType = dayType;
    }

    /// <summary>
    /// Create a special day with a code
    /// </summary>
    /// <param name="date"></param>
    /// <param name="dayCode"></param>
    /// <param name="dayType"></param>
    public SpecialDay(BadiDate date, HolyDayCode dayCode, SpecialDayType dayType) : this()
    {
      Date = date;
      DayType = dayType;
      DayCode = dayCode;
    }


    /// <summary>
    /// Create a special day with a code
    /// </summary>
    /// <param name="date"></param>
    /// <param name="dayCode"></param>
    /// <param name="dayType"></param>
    /// <param name="timeCode"></param>
    public SpecialDay(BadiDate date, HolyDayCode dayCode, SpecialDayType dayType, SpecialTimeCode timeCode) : this()
    {
      Date = date;
      DayType = dayType;
      DayCode = dayCode;
      TimeCode = timeCode;
    }

    /// <summary>
    /// The date of this special day
    /// </summary>
    public BadiDate Date { get; private set; }
    /// <summary>
    /// The type of this special day
    /// </summary>
    public SpecialDayType DayType { get; private set; }

    /// <summary>
    /// The code for this day, if any
    /// </summary>
    public HolyDayCode DayCode { get; private set; }

    /// <summary>
    /// Time of day when this Holy Day should be observed
    /// </summary>
    public SpecialTimeCode TimeCode { get; private set; }
  }
}
