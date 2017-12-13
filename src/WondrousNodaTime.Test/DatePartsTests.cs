// Copyright 2017 Glen Little. All rights reserved.
// Use of this source code is governed by the Apache License 2.0,
// as found in the LICENSE.txt file.

using NUnit.Framework;

namespace WondrousNodaTime.Test
{
  class DatePartsTests
  {
    [Test]
    [TestCase(180, 0, 0)]
    [TestCase(180, 1, 1)]
    [TestCase(180, 3, 1)]
    [TestCase(180, 4, 2)]
    [TestCase(180, 7, 2)]
    [TestCase(180, 8, 3)]
    [TestCase(180, 13, 3)]
    [TestCase(180, 14, 4)]
    [TestCase(180, 19, 4)]
    public void Element(int year, int month, int elementNum)
    {
      new WondrousDate(year, month, 1).Element.ShouldEqual(elementNum);
    }

    [Test]
    [TestCase(1, 1)]
    [TestCase(19, 1)]
    [TestCase(20, 2)]
    [TestCase(171, 9)]
    [TestCase(172, 10)]
    public void Unity(int year, int unity) {
      new WondrousDate(year, 1, 1).Unity.ShouldEqual(unity);
      new WondrousDate(year, 19, 19).Unity.ShouldEqual(unity);
      new WondrousDate(year, 0, 1).Unity.ShouldEqual(unity);
    }


    [Test]
    [TestCase(1, 1)]
    [TestCase(19, 19)]
    [TestCase(20, 1)]
    [TestCase(171, 19)]
    [TestCase(172, 1)]
    public void YearOfUnity(int year, int yearOfUnity)
    {
      new WondrousDate(year, 1, 1).YearOfUnity.ShouldEqual(yearOfUnity);
      new WondrousDate(year, 19, 19).YearOfUnity.ShouldEqual(yearOfUnity);
      new WondrousDate(year, 0, 1).YearOfUnity.ShouldEqual(yearOfUnity);
    }

    [Test]
    [TestCase(1, 1)]
    [TestCase(360, 1)]
    [TestCase(361, 1)]
    [TestCase(362, 2)]
    [TestCase(722, 2)]
    [TestCase(723, 3)]
    public void AllThings(int year, int allThings)
    {
      new WondrousDate(year, 1, 1).AllThings.ShouldEqual(allThings);
    }
  }
}
