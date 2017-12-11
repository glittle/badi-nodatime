// Copyright 2017 Glen Little. All rights reserved.
// Use of this source code is governed by the Apache License 2.0,
// as found in the LICENSE.txt file.

using System;
using System.Collections.Generic;
using WondrousNodaTime;
using NUnit.Framework;
using NodaTime;

namespace WondrousNodaTime.Test
{
  public partial class CoreTest
  {
    [Test]
    public void CreateDate()
    {
      Wondrous.CreateDate(180, 10, 10).ToWondrousString().ShouldEqual("180-10-10");
      Wondrous.CreateDate(180, 18, 19).ToWondrousString().ShouldEqual("180-18-19");
      Wondrous.CreateDate(180, 0, 3).ToWondrousString().ShouldEqual("180-0-3");
      Wondrous.CreateDate(180, 19, 1).ToWondrousString().ShouldEqual("180-19-1");
    }

    [Test]
    public void EnsureIsWondrous()
    {
      Assert.Throws<ArgumentException>(() => new LocalDate(2000, 1, 1).ToWondrousString());
    }

    [Test]
    [TestCase(0,0)]
    [TestCase(1, 1)]
    [TestCase(3, 1)]
    [TestCase(4, 2)]
    [TestCase(7, 2)]
    [TestCase(8, 3)]
    [TestCase(13, 3)]
    [TestCase(14, 4)]
    [TestCase(19, 4)]
    public void ElementNumber(int month, int element)
    {
      Wondrous.Element(month).ShouldEqual(element);
    }
  }
}
