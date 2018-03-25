// Copyright 2017 Glen Little. All rights reserved.
// Use of this source code is governed by the Apache License 2.0,
// as found in the LICENSE.txt file.

using Xunit;
using BadiNodaTime.Utility;
using BadiNodaTime;

namespace BadiNodaTimeTest
{
  public class CreateTests
  {
    [Theory]
    [InlineData(180, 10, 10)]
    [InlineData(180, 18, 19)]
    [InlineData(180, 0, 3)]
    [InlineData(180, 19, 1)]
    public void ToBadiString_Default(int year, int month, int day)
    {
      // ensure that this helper method is working
      new BadiDate(year, month, day).ToString().ShouldEqual($"{year}-{month}-{day}");
    }

    //[Theory]
    //public void ToLocalDate()
    //{
    //}

    [Theory]
    [InlineData(180, 10, 10)]
    [InlineData(180, 18, 19)]
    [InlineData(180, 0, 3)]
    [InlineData(180, 19, 1)]
    public void CreateDate_Day(int year, int month, int day)
    {
      new BadiDate(year, month, day).Day.ShouldEqual(day);
    }

    [Theory]
    [InlineData(180, 10, 10)]
    [InlineData(180, 18, 19)]
    [InlineData(180, 0, 3)]
    [InlineData(180, 19, 1)]
    public void CreateDate_Month(int year, int month, int day)
    {
      new BadiDate(year, month, day).Month.ShouldEqual(month);
    }

  }
}
