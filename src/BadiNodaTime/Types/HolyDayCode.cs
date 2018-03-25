// Copyright 2017 Glen Little. All rights reserved.
// Use of this source code is governed by the Apache License 2.0,
// as found in the LICENSE.txt file.

using System;

namespace BadiNodaTime
{
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
}
