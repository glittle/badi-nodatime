// Copyright 2017 Glen Little. All rights reserved.
// Use of this source code is governed by the Apache License 2.0,
// as found in the LICENSE.txt file.

using System;

namespace WondrousNodaTime
{

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
