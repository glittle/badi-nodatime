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
    public SpecialDay(WondrousDate date, SpecialDayType dayType) : this()
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
    public SpecialDay(WondrousDate date, HolyDayCode dayCode, SpecialDayType dayType) : this()
    {
      Date = date;
      DayType = dayType;
      DayCode = dayCode;
    }

    /// <summary>
    /// The date of this special day
    /// </summary>
    public WondrousDate Date { get; private set; }
    /// <summary>
    /// The type of this special day
    /// </summary>
    public SpecialDayType DayType { get; private set; }

    /// <summary>
    /// The code for this day, if any
    /// </summary>
    public HolyDayCode DayCode { get; private set; }
  }

  /// <summary>
  /// Holy Day Codes
  /// </summary>
  [Flags]
  public enum HolyDayCode
  {
    _NoCode_ = 0,
    NawRuz = 1,
    Ridvan1 = 2,
    Ridvan9 = 4,
    Ridvan12 = 8,
    AscBaha = 16,
    DeclBab = 32,
    Martrydom = 64,
    BirthBab = 128,
    BirthBaha = 256,
    AscAbdul = 512,
    Covenant = 1024
  }

  /// <summary>
  /// Types of special days
  /// </summary>
  [Flags]
  public enum SpecialDayType
  {
    /// <summary>
    /// A Holy Day when work and school should be suspended
    /// </summary>
    HolyDay_WorkSuspended = 1,
    /// <summary>
    /// A Holy Day not requiring suspension of work and school
    /// </summary>
    HolyDay_Other = 2,
    /// <summary>
    /// The first day of a month
    /// </summary>
    FeastDay = 4,
    /// <summary>
    /// A day of fasting from sunrise to sunset
    /// </summary>
    FastingDay = 8
  }
}
