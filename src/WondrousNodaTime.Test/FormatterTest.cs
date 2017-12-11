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
      Wondrous.CreateDate(180, 10, 10).ToWondrousString().ShouldEqual("180-10-10");
      Wondrous.CreateDate(180, 18, 19).ToWondrousString().ShouldEqual("180-18-19");
      Wondrous.CreateDate(180, 0, 3).ToWondrousString().ShouldEqual("180-0-3");
      Wondrous.CreateDate(180, 19, 1).ToWondrousString().ShouldEqual("180-19-1");
    }

  }
}
