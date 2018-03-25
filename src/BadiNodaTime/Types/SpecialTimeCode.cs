// Copyright 2017 Glen Little. All rights reserved.
// Use of this source code is governed by the Apache License 2.0,
// as found in the LICENSE.txt file.

using System;

namespace BadiNodaTime
{
  /// <summary>
  /// Some Holy Days are to be observed at specific times.
  /// </summary>
  public enum SpecialTimeCode {
    /// <summary>
    /// No special time
    /// </summary>
    _NoCode_ = 0,
    /// <summary>
    /// 1:00 Standard Time
    /// </summary>
    H01,
    /// <summary>
    /// 3:00 Standard Time
    /// </summary>
    H03,
    /// <summary>
    /// 12:00 (noon) Standard Time
    /// </summary>
    H12,
    /// <summary>
    /// 15:00 Standard Time
    /// </summary>
    H15,
    /// <summary>
    /// 2 hours after sunset
    /// </summary>
    SS2
  }
}
