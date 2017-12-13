// Copyright 2017 Glen Little. All rights reserved.
// Use of this source code is governed by the Apache License 2.0,
// as found in the LICENSE.txt file.

using NodaTime;
using NUnit.Framework;
using System;
using WondrousNodaTime.Utility;

namespace WondrousNodaTime.Test
{
  class UtilityTests
  {
    [Test]
    public void CheckIsWondrousDate()
    {
      Checks.EnsureIsWondrousCalendar(new WondrousDate().LocalDate, "Okay");

      Assert.Throws<ArgumentException>(() => Checks.EnsureIsWondrousCalendar(new LocalDate(), "Should Fail"));
    }

    [Test]
    public void CheckNotNull()
    {
      Checks.CheckNotNull("", "Okay");

      string s = null;
      Assert.Throws<ArgumentNullException>(() => Checks.CheckNotNull(s, "Should Fail"));
    }


    [Test]
    public void CheckArgument()
    {
      Checks.CheckArgument("a" == "a", "Test1", "Okay");

      Assert.Throws<ArgumentException>(() => Checks.CheckArgument("a" == "b", "Test2", "Should Fail"));
    }
  }

}
