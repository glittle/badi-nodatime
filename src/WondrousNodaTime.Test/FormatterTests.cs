// Copyright 2017 Glen Little. All rights reserved.
// Use of this source code is governed by the Apache License 2.0,
// as found in the LICENSE.txt file.

using NUnit.Framework;

namespace WondrousNodaTime.Test
{
  class FormatterTests
  {
    [Test]
    [TestCase(180, 10, 10, "180-10-10")]
    [TestCase(180, 18, 19, "180-18-19")]
    [TestCase(180, 0, 3, "180-0-3")]
    [TestCase(180, 19, 1, "180-19-1")]
    public void ToString_Default(int year, int month, int day, string result)
    {
      new WondrousDate(year, month, day).ToString().ShouldEqual(result);
    }


    [Test]
    [TestCase(180, 10, 10, "2023-9-17")]
    [TestCase(180, 18, 19, "2024-2-25")]
    [TestCase(180, 0, 3, "2024-2-28")]
    [TestCase(180, 19, 1, "2024-3-1")]
    public void ToString_G(int year, int month, int day, string result)
    {
      new WondrousDate(year, month, day).ToString("{G}").ShouldEqual(result);
    }
  }
}
