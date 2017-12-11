// Copyright 2017 Glen Little. All rights reserved.
// Use of this source code is governed by the Apache License 2.0,
// as found in the LICENSE.txt file.
using NodaTime;

namespace WondrousNodaTime
{
  /// <summary>
  /// Extension methods for the Wondrous calendar
  /// </summary>
  public static class Extensions
  {
    /// <summary>
    /// A string representing this Wondrous Date
    /// </summary>
    /// <param name="input"></param>
    /// <param name="format"></param>
    /// <returns></returns>
    public static string ToWondrousString(this LocalDate input, string format = "") => Formatter.ToWondrousString(input, format);

    /// <summary>
    /// Return the month of this Wondrous date. If in Ayyam-i-Ha, returns 0.
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static int Month(this LocalDate input) => Wondrous.Month(input);

    /// <summary>
    /// Return the day of this Wondrous month or Ayyam-i-Ha.
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static int Day(this LocalDate input) => Wondrous.Day(input);
  }
}
