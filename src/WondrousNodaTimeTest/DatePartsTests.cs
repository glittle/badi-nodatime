// Copyright 2017 Glen Little. All rights reserved.
// Use of this source code is governed by the Apache License 2.0,
// as found in the LICENSE.txt file.

using WondrousNodaTime;
using Xunit;

namespace WondrousNodaTimeTest
{
  public class DatePartsTests
  {
    [Theory]
    [InlineData(180, 0, 0)]
    [InlineData(180, 1, 1)]
    [InlineData(180, 3, 1)]
    [InlineData(180, 4, 2)]
    [InlineData(180, 7, 2)]
    [InlineData(180, 8, 3)]
    [InlineData(180, 13, 3)]
    [InlineData(180, 14, 4)]
    [InlineData(180, 19, 4)]
    public void Element(int year, int month, int elementNum)
    {
      new WondrousDate(year, month, 1).Element.ShouldEqual(elementNum);
    }

    [Theory]
    [InlineData(1, 1)]
    [InlineData(19, 1)]
    [InlineData(20, 2)]
    [InlineData(171, 9)]
    [InlineData(172, 10)]
    public void Unity(int year, int unity)
    {
      new WondrousDate(year, 1, 1).Unity.ShouldEqual(unity);
      new WondrousDate(year, 19, 19).Unity.ShouldEqual(unity);
      new WondrousDate(year, 0, 1).Unity.ShouldEqual(unity);
    }


    [Theory]
    [InlineData(1, 1)]
    [InlineData(19, 19)]
    [InlineData(20, 1)]
    [InlineData(171, 19)]
    [InlineData(172, 1)]
    public void YearOfUnity(int year, int yearOfUnity)
    {
      new WondrousDate(year, 1, 1).YearOfUnity.ShouldEqual(yearOfUnity);
      new WondrousDate(year, 19, 19).YearOfUnity.ShouldEqual(yearOfUnity);
      new WondrousDate(year, 0, 1).YearOfUnity.ShouldEqual(yearOfUnity);
    }

    [Theory]
    [InlineData(1, 1)]
    [InlineData(360, 1)]
    [InlineData(361, 1)]
    [InlineData(362, 2)]
    [InlineData(722, 2)]
    [InlineData(723, 3)]
    public void AllThings(int year, int allThings)
    {
      new WondrousDate(year, 1, 1).AllThings.ShouldEqual(allThings);
    }


    [Theory]
    [InlineData(174, 15, 6, 1)]
    [InlineData(174, 15, 5, 7)]
    public void Weekday(int year, int month, int day, int dow)
    {
      new WondrousDate(year, month, day).Weekday.ShouldEqual(dow);
    }
  }
}
