// Copyright 2017 Glen Little. All rights reserved.
// Use of this source code is governed by the Apache License 2.0,
// as found in the LICENSE.txt file.

using System;
using System.Collections.Generic;
using BadiNodaTime;
using Xunit;
using NodaTime;

namespace BadiNodaTimeTest
{
  public class CoreTest
  {
    [Fact]
    public void CreateDateNow() {
      var b = new BadiDate();
      var g = DateTime.Today;

      var g2 = b.WithCalendar(CalendarSystem.Gregorian);
      g2.Year.ShouldEqual(g.Year);
      g2.Month.ShouldEqual(g.Month);
      g2.Day.ShouldEqual(g.Day);
    }
    [Fact]
    public void CreateDate()
    {
      new BadiDate(180, 10, 10).ToString().ShouldEqual("180-10-10");
      new BadiDate(180, 18, 19).ToString().ShouldEqual("180-18-19");
      new BadiDate(180, 0, 3).ToString().ShouldEqual("180-0-3");
      new BadiDate(180, 19, 1).ToString().ShouldEqual("180-19-1");
    }

    [Fact]
    public void CreateDate_FromBadiLocalDate()
    {
      var d1 = new BadiDate(180, 19, 1);
      var d2 = new BadiDate(d1.LocalDate);
      d2.Month.ShouldEqual(19);
    }

    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 1)]
    [InlineData(3, 1)]
    [InlineData(4, 2)]
    [InlineData(7, 2)]
    [InlineData(8, 3)]
    [InlineData(13, 3)]
    [InlineData(14, 4)]
    [InlineData(19, 4)]
    public void ElementNumber(int month, int element)
    {
      new BadiDate(180, month, 1).Element.ShouldEqual(element);
    }

    [Theory]
    [InlineData(2016, 2, 26, 172, 0, 1)]
    [InlineData(2016, 2, 29, 172, 0, 4)]
    [InlineData(2016, 3, 1, 172, 19, 1)]
    [InlineData(2016, 3, 20, 173, 1, 1)]
    [InlineData(2016, 3, 21, 173, 1, 2)]
    [InlineData(2016, 5, 26, 173, 4, 11)]
    [InlineData(2062, 3, 20, 219, 1, 1)]
    [InlineData(2063, 3, 20, 220, 1, 1)]
    [InlineData(2064, 3, 20, 221, 1, 1)]
    public void GeneralConversion(int gYear, int gMonth, int gDay, int bYear, int bMonth, int bDay)
    {
      // create in the Badíʿ calendar
      var wDate = new BadiDate(bYear, bMonth, bDay);

      // convert to gregorian and check
      var gDate = wDate.WithCalendar(CalendarSystem.Gregorian);
      gDate.Year.ShouldEqual(gYear);
      gDate.Month.ShouldEqual(gMonth);
      gDate.Day.ShouldEqual(gDay);

      // convert from a LocalDate
      var wDate2 = new BadiDate(new LocalDate(gYear, gMonth, gDay));
      wDate2.YearOfEra.ShouldEqual(bYear);
      wDate2.Month.ShouldEqual(bMonth);
      wDate2.Day.ShouldEqual(bDay);
    }

    [Theory]
    [InlineData(2016, 2, 26, 172, 0, 1)]
    [InlineData(2016, 2, 29, 172, 0, 4)]
    [InlineData(2016, 3, 1, 172, 19, 1)]
    [InlineData(2016, 3, 20, 173, 1, 1)]
    [InlineData(2016, 3, 21, 173, 1, 2)]
    [InlineData(2016, 5, 26, 173, 4, 11)]
    [InlineData(2062, 3, 20, 219, 1, 1)]
    [InlineData(2063, 3, 20, 220, 1, 1)]
    [InlineData(2064, 3, 20, 221, 1, 1)]
    public void DatesAreEquals(int gYear, int gMonth, int gDay, int bYear, int bMonth, int bDay)
    {
      var wDate2 = new BadiDate(new LocalDate(gYear, gMonth, gDay));
      var wDate3 = new BadiDate(new DateTime(gYear, gMonth, gDay));

      Assert.True(wDate3.Equals(wDate2));

      wDate3.ShouldEqual(new BadiDate(bYear, bMonth, bDay));
    }

    [Theory]
    [InlineData(2016, 2, 26, 172, 0, 1)]
    [InlineData(2016, 2, 29, 172, 0, 4)]
    [InlineData(2016, 3, 1, 172, 19, 1)]
    [InlineData(2016, 3, 20, 173, 1, 1)]
    [InlineData(2016, 3, 21, 173, 1, 2)]
    public void ToLocalDate(int gYear, int gMonth, int gDay, int bYear, int bMonth, int bDay)
    {
      var wDate = new BadiDate(bYear, bMonth, bDay);
      var localDate = wDate.LocalDate.WithCalendar(CalendarSystem.Gregorian);
      localDate.Year.ShouldEqual(gYear);
      localDate.Month.ShouldEqual(gMonth);
      localDate.Day.ShouldEqual(gDay);

      var dateTime = wDate.DateTime;
      dateTime.Year.ShouldEqual(gYear);
      dateTime.Month.ShouldEqual(gMonth);
      dateTime.Day.ShouldEqual(gDay);
    }
  }
}
