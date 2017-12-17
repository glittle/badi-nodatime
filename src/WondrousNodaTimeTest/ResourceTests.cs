// Copyright 2017 Glen Little. All rights reserved.
// Use of this source code is governed by the Apache License 2.0,
// as found in the LICENSE.txt file.

using System;
using System.Collections.Generic;
using System.Linq;
using WondrousNodaTime;
using WondrousNodaTime.Resources;
using Xunit;

namespace WondrousNodaTimeTest
{
  public class ResourceTests
  {
    [Theory]
    [InlineData("EraAbbrev", "B.E.")]
    [InlineData("HolyDay_BirthBaha", "Birth of Bahá'u'lláh")]
    [InlineData("InvalidCode", "[?InvalidCode]")]
    public void GetString(string key, string result)
    {
      WondrousResources _resolver = new WondrousResources("en");

      _resolver.GetString(key).ShouldEqual(result);
    }

    [Theory]
    [InlineData("MonthMeaning", 1, "Splendor")]
    [InlineData("MonthMeaning", 19, "Loftiness")]
    public void GetListItem(string key, int index, string result)
    {
      WondrousResources _resolver = new WondrousResources("en");

      _resolver.GetListItem(key, index).ShouldEqual(result);
    }

    [Theory]
    [InlineData(HolyDayCode.BirthBab, "Birth of the Báb", "")]
    [InlineData(HolyDayCode.AscAbdul, "Ascension of `Abdu'l-Bahá", "1 am (Standard Time)")]
    public void HolyDayNames(HolyDayCode code, string name, string time)
    {
      WondrousResources _resolver = new WondrousResources("en");

      _resolver.GetString("HolyDay_" + code).ShouldEqual(name);

      var yi = new WondrousYearInfo(174);
      var holyDay = yi.GetSpecialDays(SpecialDayType.HolyDay_Other, code).First();

      if (holyDay.TimeCode != SpecialTimeCode._NoCode_)
      {
        _resolver.GetString("SpecialTime_" + holyDay.TimeCode).ShouldEqual(time);
      }
    }

    [Fact]
    public void CustomProvider()
    {
      var myDictionary = new Dictionary<string, string> {
        { "myKey", "myValue" },
        { "hello?", "goodbye!" },
      };

      WondrousResources _resolver = new WondrousResources("en", key =>
      {
        if (myDictionary.ContainsKey(key))
        {
          return myDictionary[key];
        }
        return null;
      });

      _resolver.GetString("EraShort").ShouldEqual("BE"); // normal matches work
      _resolver.GetString("myKey").ShouldEqual("myValue");
      _resolver.GetString("hello?").ShouldEqual("goodbye!");
    }

  }
}
