// Copyright 2017 Glen Little. All rights reserved.
// Use of this source code is governed by the Apache License 2.0,
// as found in the LICENSE.txt file.

using NodaTime;
using Xunit;
using System;
using BadiNodaTime.Utility;
using BadiNodaTime;
using BadiNodaTime.Resources;

namespace BadiNodaTimeTest
{
  public class UtilityTests
  {
    [Fact]
    public void CheckIsBadiDate()
    {
      Checks.EnsureIsBadiCalendar(new BadiDate().LocalDate, "Okay");

      Assert.Throws<ArgumentException>(() => Checks.EnsureIsBadiCalendar(new LocalDate(), "Should Fail"));
    }

    [Fact]
    public void CheckNotNull()
    {
      Checks.CheckNotNull("", "Okay");

      string s = null;
      Assert.Throws<ArgumentNullException>(() => Checks.CheckNotNull(s, "Should Fail"));
    }


    [Fact]
    public void CheckArgument()
    {
      Checks.CheckArgument("a" == "a", "Test1", "Okay");

      Assert.Throws<ArgumentException>(() => Checks.CheckArgument("a" == "b", "Test2", "Should Fail"));
    }
  }
}
