// Copyright 2017 Glen Little. All rights reserved.
// Use of this source code is governed by the Apache License 2.0,
// as found in the LICENSE.txt file.


using BadiNodaTime;
using Xunit;

namespace BadiNodaTimeTest
{
  public class LocalDateTests {

    [Fact]
    public void Plus()
    {
      var w1 = new BadiDate(180, 8, 10);
      w1.PlusDays(2).Day.ShouldEqual(12);
      w1.PlusDays(20).Day.ShouldEqual(11);
      w1.PlusDays(-9).ToString().ShouldEqual("180-8-1");

      w1.PlusYears(2).ToString().ShouldEqual("182-8-10");
      w1.PlusYears(-2).ToString().ShouldEqual("178-8-10");
    }

  }
}
