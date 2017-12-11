// Copyright 2017 Glen Little. All rights reserved.
// Use of this source code is governed by the Apache License 2.0,
// as found in the LICENSE.txt file.

using NUnit.Framework;

namespace WondrousNodaTime.Test
{
  class ExtensionsTest
  {
    [Test]
    [TestCase(180, 10, 10)]
    [TestCase(180, 18, 19)]
    [TestCase(180, 0, 3)]
    [TestCase(180, 19, 1)]
    public void ToWondrousString_Default(int year, int month, int day)
    {
      // ensure that this helper method is working
      Assert.AreEqual(Wondrous.CreateDate(year, month, day).ToWondrousString(), $"{year}-{month}-{day}");
    }


    [Test]
    [TestCase(180, 10, 10)]
    [TestCase(180, 18, 19)]
    [TestCase(180, 0, 3)]
    [TestCase(180, 19, 1)]
    public void CreateDate_Day(int year, int month, int day)
    {
      Assert.AreEqual(Wondrous.CreateDate(year, month, day).Day(), day);
    }

    [Test]
    [TestCase(180, 10, 10)]
    [TestCase(180, 18, 19)]
    [TestCase(180, 0, 3)]
    [TestCase(180, 19, 1)]
    public void CreateDate_Month(int year, int month, int day)
    {
      Assert.AreEqual(Wondrous.CreateDate(year, month, day).Month(), month);
    }

  }
}
