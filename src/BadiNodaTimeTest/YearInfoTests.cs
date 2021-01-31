﻿// Copyright 2017 Glen Little. All rights reserved.
// Use of this source code is governed by the Apache License 2.0,
// as found in the LICENSE.txt file.

using NodaTime;
using Xunit;
using System.Linq;
using BadiNodaTime;

namespace BadiNodaTimeTest
{
  public class YearInfoTests
  {
    [Theory]
    [InlineData(172, false)]
    [InlineData(173, false)]
    [InlineData(207, true)]
    [InlineData(220, true)]
    public void IsLeapYear(int year, bool isLeapYear)
    {
      new BadiYearInfo(year).IsLeapYear.ShouldEqual(isLeapYear);
    }

    [Theory]
    [InlineData(172, 4)]
    [InlineData(173, 4)]
    [InlineData(207, 5)]
    [InlineData(220, 5)]
    public void DaysInAyyamiHa(int year, int days)
    {
      new BadiYearInfo(year).DaysInAyyamiHa.ShouldEqual(days);
    }

    [Fact]
    public void GetSpecialDays()
    {
      var yi = new BadiYearInfo(174);
      var list = yi.GetSpecialDays(SpecialDayType.FeastDay | SpecialDayType.FastingDay).ToList();

      // not done yet... 
      list.Count().ShouldEqual(19 * 2);
    }


    [Fact]
    public void HolyDays_Main()
    {
      var yi = new BadiYearInfo(174);
      var list = yi.GetSpecialDays(SpecialDayType.HolyDay_WorkSuspended).ToList();

      list.Count().ShouldEqual(9);

      list[0].Date.LocalDate.DayOfYear.ShouldEqual(1);

      list[0].Date.ToShortIsoDate().ShouldEqual("2017-3-20");
      list[1].Date.ToShortIsoDate().ShouldEqual("2017-4-20");
      list[2].Date.ToShortIsoDate().ShouldEqual("2017-4-28");
      list[3].Date.ToShortIsoDate().ShouldEqual("2017-5-1");
      list[4].Date.ToShortIsoDate().ShouldEqual("2017-5-23");
      list[5].Date.ToShortIsoDate().ShouldEqual("2017-5-28");
      list[6].Date.ToShortIsoDate().ShouldEqual("2017-7-9");
      list[7].Date.ToShortIsoDate().ShouldEqual("2017-10-21");
      list[8].Date.ToShortIsoDate().ShouldEqual("2017-10-22");
    }

    [Fact]
    public void HolyDays_Per171()
    {
      var yi = new BadiYearInfo(170);
      var list = yi.GetSpecialDays(SpecialDayType.HolyDay_WorkSuspended).ToList();

      list.Count().ShouldEqual(9);

      list[0].Date.LocalDate.DayOfYear.ShouldEqual(1);

      list[0].Date.ToShortIsoDate().ShouldEqual("2013-3-21");
      list[1].Date.ToShortIsoDate().ShouldEqual("2013-4-21");
      list[2].Date.ToShortIsoDate().ShouldEqual("2013-4-29");
      list[3].Date.ToShortIsoDate().ShouldEqual("2013-5-2");
      list[4].Date.ToShortIsoDate().ShouldEqual("2013-5-23");
      list[5].Date.ToShortIsoDate().ShouldEqual("2013-5-29");
      list[6].Date.ToShortIsoDate().ShouldEqual("2013-7-9");
      list[7].Date.ToShortIsoDate().ShouldEqual("2013-10-20");
      list[8].Date.ToShortIsoDate().ShouldEqual("2013-11-12");
    }

    [Fact]
    public void HolyDays_Other()
    {
      var yi = new BadiYearInfo(174);
      var list = yi.GetSpecialDays(SpecialDayType.HolyDay_Other).ToList();

      list.Count().ShouldEqual(2);

      list[0].Date.ToShortIsoDate().ShouldEqual("2017-11-25");
      list[1].Date.ToShortIsoDate().ShouldEqual("2017-11-27");

      var hd1 = list[0];
      hd1.DayCode.ShouldEqual(HolyDayCode.Covenant);
      hd1.DayType.ShouldEqual(SpecialDayType.HolyDay_Other);

      var hd2 = list[1];
      hd2.TimeCode.ShouldEqual(SpecialTimeCode.H01);
      hd2.DayCode.ShouldEqual(HolyDayCode.AscAbdul);
    }

    [Fact]
    public void GetSpecialDays_HolyDaysWanted()
    {
        var yearInfo = new BadiYearInfo(174);

        var specialDaysList = yearInfo.GetSpecialDays(SpecialDayType.HolyDay_WorkSuspended, HolyDayCode.NawRuz);
        specialDaysList.Count().ShouldEqual(1);

        specialDaysList = yearInfo.GetSpecialDays(SpecialDayType.HolyDay_WorkSuspended, HolyDayCode.Ridvan1);
        specialDaysList.Count().ShouldEqual(1);
    }
  }
}
