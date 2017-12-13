// Copyright 2017 Glen Little. All rights reserved.
// Use of this source code is governed by the Apache License 2.0,
// as found in the LICENSE.txt file.

using NUnit.Framework;

namespace WondrousNodaTime.Test
{
  class FormatterTest
  {
    [Test]
    public void ToString_Default()
    {
      // ensure that this helper method is working
      new WondrousDate(180, 10, 10).ToString().ShouldEqual("180-10-10");
      new WondrousDate(180, 18, 19).ToString().ShouldEqual("180-18-19");
      new WondrousDate(180, 0, 3).ToString().ShouldEqual("180-0-3");
      new WondrousDate(180, 19, 1).ToString().ShouldEqual("180-19-1");
    }

  }
}
