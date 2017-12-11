// Copyright 2017 Glen Little. All rights reserved.
// Use of this source code is governed by the Apache License 2.0,
// as found in the LICENSE.txt file.

using NUnit.Framework;

namespace WondrousNodaTime.Test
{
  class FormatterTest
  {
    [Test]
    public void ToWondrousString_Default()
    {
      // ensure that this helper method is working
      Assert.AreEqual(Wondrous.CreateDate(180, 10, 10).ToWondrousString(), "180-10-10");
      Assert.AreEqual(Wondrous.CreateDate(180, 18, 19).ToWondrousString(), "180-18-19");
      Assert.AreEqual(Wondrous.CreateDate(180, 0, 3).ToWondrousString(), "180-0-3");
      Assert.AreEqual(Wondrous.CreateDate(180, 19, 1).ToWondrousString(), "180-19-1");
    }

  }
}
