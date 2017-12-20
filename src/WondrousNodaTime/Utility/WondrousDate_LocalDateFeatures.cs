// Copyright 2017 Glen Little. All rights reserved.
// Use of this source code is governed by the Apache License 2.0,
// as found in the LICENSE.txt file.


using NodaTime;

namespace WondrousNodaTime
{
  public partial class WondrousDate
  {
    /// <summary>
    /// Returns a new WondrousDate a number of days after (or before) this date
    /// </summary>
    /// <param name="years">Days to add or subtract to the current date</param>
    /// <returns></returns>
    public WondrousDate PlusDays(int days)
    {
      return new WondrousDate(_date.PlusDays(days));
    }


    /// <summary>
    /// Returns a new WondrousDate a number of days after (or before) this date
    /// </summary>
    /// <param name="years">Days to add or subtract to the current date</param>
    /// <returns></returns>
    public WondrousDate PlusYears(int years)
    {
      return new WondrousDate(_date.PlusYears(years));
    }
  }
}
