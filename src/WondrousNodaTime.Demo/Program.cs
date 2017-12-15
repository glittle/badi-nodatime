// Copyright 2017 The Noda Time Authors. All rights reserved.
// Use of this source code is governed by the Apache License 2.0,
// as found in the LICENSE.txt file.
using NUnitLite;
using System;
using System.Linq;
using System.Reflection;
using WondrousNodaTime;

namespace NodaTime.Demo
{
  class Program
  {
    public static int Main(string[] args)
    {
      Console.WriteLine($"Today is {new WondrousDate().ToString("{W} ({G})")}");

      var yi = new WondrousYearInfo(174);
      var nawRuz = yi.GetSpecialDays(SpecialDayType.HolyDay_WorkSuspended, HolyDayCode.NawRuz).First();

      Console.WriteLine($"Naw Ruz was on {nawRuz.Date.ToString("{W} ({G})")}");

      return 0;
    }
  }
}
