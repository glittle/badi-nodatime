// Copyright 2017 Glen Little. All rights reserved.
// Use of this source code is governed by the Apache License 2.0,
// as found in the LICENSE.txt file.

using NUnit.Framework;
using System.Linq;

namespace WondrousNodaTime.Test
{
  class YearInfoTests
  {
    [Test]
    [TestCase(172, false)]
    [TestCase(173, false)]
    [TestCase(207, true)]
    [TestCase(220, true)]
    public void IsLeapYear(int year, bool isLeapYear)
    {
      new YearInfo(year).IsLeapYear.ShouldEqual(isLeapYear);
    }

    [Test]
    [TestCase(172, 4)]
    [TestCase(173, 4)]
    [TestCase(207, 5)]
    [TestCase(220, 5)]
    public void DaysInAyyamiHa(int year, int days)
    {
      new YearInfo(year).DaysInAyyamiHa.ShouldEqual(days);
    }

    [Test]
    public void GetSpecialDays() {
      var yi = new YearInfo(174);
      var list = yi.GetSpecialDays(SpecialDayEnum.FeastDay | SpecialDayEnum.FastingDay).ToList();

      // not done yet... 
      list.Count().ShouldEqual(1);
    }
  }
}
