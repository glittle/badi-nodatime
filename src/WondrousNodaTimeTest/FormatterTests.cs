// Copyright 2017 Glen Little. All rights reserved.
// Use of this source code is governed by the Apache License 2.0,
// as found in the LICENSE.txt file.

using Xunit;

namespace WondrousNodaTime.Test
{
  class FormatterTests
  {
    [Theory]
    [InlineData(180, 10, 10, "180-10-10")]
    [InlineData(180, 18, 19, "180-18-19")]
    [InlineData(180, 0, 3, "180-0-3")]
    [InlineData(180, 19, 1, "180-19-1")]
    public void ToString_Default(int year, int month, int day, string result)
    {
      new WondrousDate(year, month, day).ToString("{W}").ShouldEqual(result);
    }


    [Theory]
    [InlineData(180, 10, 10, "2023-9-17")]
    [InlineData(180, 18, 19, "2024-2-25")]
    [InlineData(180, 0, 3, "2024-2-28")]
    [InlineData(180, 19, 1, "2024-3-1")]
    public void ToString_G(int year, int month, int day, string result)
    {
      new WondrousDate(year, month, day).ToString("{G}").ShouldEqual(result);
    }


    [Theory]
    [InlineData(180, 10, 9, "{day_Num00} {month_Meaning} {yearOfEra}", "09 Might 180")]
    [InlineData(180, 10, 9, "{day} {month_Arabic} {yearOfEra}", "9 `Izzat 180")]
    [InlineData(180, 10, 9, "{day} {month_Arabic} {yearOfUnity}", "9 `Izzat 9")]
    public void ToString(int year, int month, int day, string format, string result)
    {
      new WondrousDate(year, month, day).ToString(format).ShouldEqual(result);
    }
  }
}
