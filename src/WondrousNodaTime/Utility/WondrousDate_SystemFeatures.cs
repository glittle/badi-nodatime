// Copyright 2017 Glen Little. All rights reserved.
// Use of this source code is governed by the Apache License 2.0,
// as found in the LICENSE.txt file.

using NodaTime;
using System;
using System.Globalization;
using WondrousNodaTime.Utility;

namespace WondrousNodaTime
{
  public partial class WondrousDate : IEquatable<WondrousDate>, IComparable<WondrousDate>, IComparable, IFormattable
  {

    /// <summary>
    /// Returns a <see cref="System.String" /> that represents this instance.
    /// </summary>
    /// <returns>
    /// The value of the current instance in the default format pattern ("D"), using the current thread's
    /// culture to obtain a format provider.
    /// </returns>
    public override string ToString() => new DateTemplateProcessor().FillTemplate(this);

    /// <summary>
    /// With pattern
    /// </summary>
    /// <param name="patternText"></param>
    /// <returns></returns>
    public string ToString(string patternText) => new DateTemplateProcessor().FillTemplate(this, patternText);

    /// <summary>
    /// Formats the value of the current instance using the specified pattern.
    /// </summary>
    /// <returns>
    /// A <see cref="T:System.String" /> containing the value of the current instance in the specified format.
    /// </returns>
    /// <param name="patternText">The <see cref="T:System.String" /> specifying the pattern to use,
    /// or null to use the default format pattern ("D").
    /// </param>
    /// <param name="formatProvider">The <see cref="T:System.IFormatProvider" /> to use when formatting the value,
    /// or null to use the current thread's culture to obtain a format provider.
    /// </param>
    /// <filterpriority>2</filterpriority>
    public string ToString(string patternText, IFormatProvider formatProvider) =>
        new DateTemplateProcessor().FillTemplate(this, patternText);

    /// <summary>
    /// Compares two <see cref="WondrousDate"/> values for equality. 
    /// </summary>
    /// <param name="other">The value to compare this date with.</param>
    /// <returns>True if the given value is another local date equal to this one; false otherwise.</returns>
    public bool Equals(WondrousDate other) => LocalDate == other.LocalDate;

    /// <summary>Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object. </summary>
    /// <returns>A value that indicates the relative order of the objects being compared. The return value has these meanings: Value Meaning Less than zero This instance precedes <paramref name="other" /> in the sort order.  Zero This instance occurs in the same position in the sort order as <paramref name="other" />. Greater than zero This instance follows <paramref name="other" /> in the sort order. </returns>
    /// <param name="other">An object to compare with this instance. </param>
    public int CompareTo(WondrousDate other) => LocalDate.CompareTo(other.LocalDate);

    /// <summary>
    /// Compare to another <see cref="LocalDate"/> 
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    int IComparable.CompareTo(object obj)
    {
      if (obj == null)
      {
        return 1;
      }
      Checks.CheckArgument(obj is LocalDate, nameof(obj), "Object must be of type NodaTime.LocalDate.");
      return CompareTo(new WondrousDate((LocalDate)obj));
    }
  }
}
