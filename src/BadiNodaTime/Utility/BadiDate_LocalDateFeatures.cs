// Copyright 2017 Glen Little. All rights reserved.
// Use of this source code is governed by the Apache License 2.0,
// as found in the LICENSE.txt file.


using NodaTime;

namespace BadiNodaTime
{
  public partial class BadiDate
  {
    /// <summary>
    /// Returns a new BadiDate a number of days after (or before) this date
    /// </summary>
    /// <param name="years">Days to add or subtract to the current date</param>
    /// <returns></returns>
    public BadiDate PlusDays(int days)
    {
      return new BadiDate(_date.PlusDays(days));
    }


    /// <summary>
    /// Returns a new BadiDate a number of days after (or before) this date
    /// </summary>
    /// <param name="years">Days to add or subtract to the current date</param>
    /// <returns></returns>
    public BadiDate PlusYears(int years)
    {
      return new BadiDate(_date.PlusYears(years));
    }
  }
}
