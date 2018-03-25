// Copyright 2017 Glen Little. All rights reserved.
// Use of this source code is governed by the Apache License 2.0,
// as found in the LICENSE.txt file.
using NodaTime;
using System;
using System.Xml;

namespace BadiNodaTime.Utility
{
  /// <summary>
  /// Check for exceptional cases.
  /// </summary>
  /// <remarks>
  /// Designed for internal use. Public to allow testing.
  /// </remarks>
  public class Checks
  {
    /// <summary>
    /// Throws exception if the date is not a Badíʿ Calendar date
    /// </summary>
    /// <param name="date"></param>
    /// <param name="paramName"></param>
    public static void EnsureIsBadiCalendar(LocalDate date, string paramName)
    {
      if (date.Calendar != CalendarSystem.Wondrous)
      {
        throw new ArgumentException("Can only be used with a LocalDate with the Badíʿ calendar system", paramName);
      }
    }

    /// <summary>
    /// Throws exception if the arg is null
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="arg"></param>
    /// <param name="paramName"></param>
    public static void CheckNotNull<T>(T arg, string paramName)
    {
      if (arg == null)
      {
        throw new ArgumentNullException(paramName);
      }
    }

    /// <summary>
    /// Throws exception if expression is false.
    /// </summary>
    /// <param name="expression"></param>
    /// <param name="paramName"></param>
    /// <param name="message"></param>
    public static void CheckArgument(bool expression, string paramName, string message)
    {
      if (!expression)
      {
        throw new ArgumentException(message, paramName);
      }
    }
  }
}
