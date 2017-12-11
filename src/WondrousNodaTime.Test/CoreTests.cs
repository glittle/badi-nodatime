// Copyright 2010 The Noda Time Authors. All rights reserved.
// Use of this source code is governed by the Apache License 2.0,
// as found in the LICENSE.txt file.

using System;
using System.Collections.Generic;
using WondrousNodaTime;
using NUnit.Framework;

namespace WondrousNodaTime.Test
{
  public partial class CoreTest
  {

    [Test]
    public void HelperMethod_WondrousDay()
    {
      Wondrous.CreateDate(180, 1, 1);

      // ensure that this helper method is working
      Assert.AreEqual(Wondrous.Day(Wondrous.CreateDate(180, 10, 10)), 10);
      Assert.AreEqual(Wondrous.Day(Wondrous.CreateDate(180, 18, 19)), 19);
      Assert.AreEqual(Wondrous.Day(Wondrous.CreateDate(180, 0, 3)), 3);
      Assert.AreEqual(Wondrous.Day(Wondrous.CreateDate(180, 19, 1)), 1);
    }

    [Test]
    public void HelperMethod_WondrousMonth()
    {
      // ensure that this helper method is working
      Assert.AreEqual(Wondrous.Month(Wondrous.CreateDate(180, 10, 10)), 10);
      Assert.AreEqual(Wondrous.Month(Wondrous.CreateDate(180, 18, 19)), 18);
      Assert.AreEqual(Wondrous.Month(Wondrous.CreateDate(180, 0, 3)), 0);
      Assert.AreEqual(Wondrous.Month(Wondrous.CreateDate(180, 19, 1)), 19);
    }

  }
}
