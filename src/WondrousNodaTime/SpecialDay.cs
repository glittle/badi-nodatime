// Copyright 2017 Glen Little. All rights reserved.
// Use of this source code is governed by the Apache License 2.0,
// as found in the LICENSE.txt file.

using System;

namespace WondrousNodaTime
{
  /// <summary>
  /// A special day in the Baha'i religious year
  /// </summary>
  public struct SpecialDay
  {
    /// <summary>
    /// Create a special day
    /// </summary>
    /// <param name="date"></param>
    /// <param name="dayType"></param>
    public SpecialDay(WondrousDate date, SpecialDayEnum dayType) : this()
    {
      Date = date;
      DayType = dayType;
    }

    /// <summary>
    /// The date of this special day
    /// </summary>
    public WondrousDate Date { get; private set; }
    /// <summary>
    /// The type of this special day
    /// </summary>
    public SpecialDayEnum DayType { get; private set; }
  }

  /// <summary>
  /// Types of special days
  /// </summary>
  public enum SpecialDayEnum {
    /// <summary>
    /// A Holy Day when work and school should be suspended
    /// </summary>
    HolyDay_NoWork,
    /// <summary>
    /// A Holy Day not requiring suspension of work and school
    /// </summary>
    HolyDay_Other,
    /// <summary>
    /// The first day of a month
    /// </summary>
    FeastDay,
    /// <summary>
    /// A day of fasting from sunrise to sunset
    /// </summary>
    FastingDay
  }
}
