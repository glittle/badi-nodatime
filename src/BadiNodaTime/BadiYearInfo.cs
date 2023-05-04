// Copyright 2017 Glen Little. All rights reserved.
// Use of this source code is governed by the Apache License 2.0,
// as found in the LICENSE.txt file.

using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using BadiNodaTime.Utility;

namespace BadiNodaTime
{
    /// <summary>
    /// Information about this year
    /// </summary>
    public class BadiYearInfo
    {
        CalendarSystem _calendarSystem = CalendarSystem.Badi;
        int _year;

        static string _twinHolyBirthdaysCode =
          "IF;NB8L?5G<OC9MB6J5IE:NC8L@5G<PD9MB7J5QF:NC8L?3G=PD:NA6J5QF;OC8L@3G=QD:MA6I5IG;O" +
          "C8K?5I=QE:MA6J5IG<OC8L?5I=PD9MB6J?SF;OC8L@6I=QE9MB7J?IF:NC9L@5I=PD:NB7K?IF;OC9MA" +
          "5G=QD:NB7J53F;OD9L@5I=QE;NB7K5IG<OD9L?5I5QE:NA6J?5G<PD8L@6I5IF:MB7J?SG<OC9L@6J=Q" +
          "E:NB7K@SG<PC8MA6J5QD:NC7K?3F;OD9MA6J=QE;NC8L?3G<OD9M@5I5QE;OB7K?2F<PE9MA6I=IF;OC" +
          "8J?3I<PD9L@6J=IF;NB7K@3G=QD9MA6J5IE:NB7K@5G<PD8LA7K5IF;NB8L@5I=OD9MA6J5QE;OB8L@3" +
          "G<PD9MB7J5IF;OC9K?5G<PE:MA6J=QF<OC8L?3G=QE:NB6J5IF;OC7K@5G=QE9MA7J5IG;OC8L@5I5PD" +
          ":MA7K?IF;OB8LA5I=QD9MB8K?3G;OC9L@6I<PE:MB7K5IF<OC9M@5I=QE:NC7J53F<PD8L@5G=QF:NB7" +
          "J53G<PD9L@5I5QE;NA7K?IG<PC8LA5I5IE:NB7K?SI<OC9LA6J=QE:MB8L?SG<OC9MA6J5PE:NC7K?3F" +
          "<PD9MA6I=QE:NC8K?3G;PD:MA6I5QF;OB7K?3G<QD9MA5I5IE;OC7K?5G<PD9L@6J5IF;NB7K?5I=PD9" +
          "M@6J?IF;NB7K@5G<PD9MA7J5IF:NC8K@5I<PD:MA7J=QE;OC8L@3G<PD:NB6J52E;OD8L@5G<PE9MA6J" +
          "5IF<OC8L?5I=PE:NA6J?IF<OB8K@5";

        /// <summary>
        /// Constructor for specific year
        /// </summary>
        /// <param name="year"></param>
        public BadiYearInfo(int year)
        {
            Checks.CheckArgument(year >= _calendarSystem.MinYear && year <= _calendarSystem.MaxYear, nameof(year), "Year out of supported range");
            _year = year;
        }

        /// <summary>
        /// Is this year a longer year?
        /// </summary>
        public int DaysInAyyamiHa
        {
            get
            {
                return IsLeapYear ? 5 : 4;
            }
        }

        /// <summary>
        /// Is this year a longer year?
        /// </summary>
        public bool IsLeapYear
        {
            get
            {
                return _calendarSystem.IsLeapYear(_year);
            }
        }

        /// <summary>
        /// A listing of special days in this year
        /// </summary>
        /// <param name="typesWanted">What type's of days?</param>
        /// <param name="holyDaysWanted">If Holy Days are wanted, but not all of them, which ones?</param>
        /// <returns></returns>
        public List<SpecialDay> GetSpecialDays(SpecialDayType typesWanted, HolyDayCode holyDaysWanted = HolyDayCode._NoCode_)
        {
            var final = new List<SpecialDay>();

            if (typesWanted.HasFlag(SpecialDayType.FeastDay))
            {
                for (int i = 0; i < 19; i++)
                {
                    final.Add(new SpecialDay(new BadiDate(_year, i + 1, 1), SpecialDayType.FeastDay));
                }
            }

            if (typesWanted.HasFlag(SpecialDayType.FastingDay))
            {
                for (int i = 0; i < 19; i++)
                {
                    final.Add(new SpecialDay(new BadiDate(_year, 19, i + 1), SpecialDayType.FastingDay));
                }
            }

            if (typesWanted.HasFlag(SpecialDayType.HolyDay_WorkSuspended))
            {
                final.Add(new SpecialDay(new BadiDate(_year, 1, 1), HolyDayCode.NawRuz, SpecialDayType.HolyDay_WorkSuspended));
                final.Add(new SpecialDay(new BadiDate(_year, 2, 13), HolyDayCode.Ridvan1, SpecialDayType.HolyDay_WorkSuspended, SpecialTimeCode.H15));
                final.Add(new SpecialDay(new BadiDate(_year, 3, 2), HolyDayCode.Ridvan9, SpecialDayType.HolyDay_WorkSuspended));
                final.Add(new SpecialDay(new BadiDate(_year, 3, 5), HolyDayCode.Ridvan12, SpecialDayType.HolyDay_WorkSuspended));
                final.Add(new SpecialDay(new BadiDate(_year, 4, 13), HolyDayCode.AscBaha, SpecialDayType.HolyDay_WorkSuspended, SpecialTimeCode.H03));

                if (_year <= 171)
                {
                    final.Add(new SpecialDay(new BadiDate(_year, 4, 7), HolyDayCode.DeclBab, SpecialDayType.HolyDay_WorkSuspended, SpecialTimeCode.SS2));
                    final.Add(new SpecialDay(new BadiDate(_year, 6, 16), HolyDayCode.Martrydom, SpecialDayType.HolyDay_WorkSuspended, SpecialTimeCode.H12));
                    final.Add(new SpecialDay(new BadiDate(_year, 12, 5), HolyDayCode.BirthBab, SpecialDayType.HolyDay_WorkSuspended));
                    final.Add(new SpecialDay(new BadiDate(_year, 13, 9), HolyDayCode.BirthBaha, SpecialDayType.HolyDay_WorkSuspended));
                }
                else
                {
                    final.Add(new SpecialDay(new BadiDate(_year, 4, 8), HolyDayCode.DeclBab, SpecialDayType.HolyDay_WorkSuspended, SpecialTimeCode.SS2));
                    final.Add(new SpecialDay(new BadiDate(_year, 6, 17), HolyDayCode.Martrydom, SpecialDayType.HolyDay_WorkSuspended, SpecialTimeCode.H12));

                    // Get from Twin Holy Birthday compressed code
                    // code is CHAR((month - 11) * 20 + 32 + day)  -- 32 is added to avoid control characters
                    var codeNum = (int)_twinHolyBirthdaysCode[_year - 172] - 32;
                    var month = 11 + codeNum / 20;
                    var day = codeNum % 20;
                    final.Add(new SpecialDay(new BadiDate(_year, month, day), HolyDayCode.BirthBab, SpecialDayType.HolyDay_WorkSuspended));

                    day++;
                    if (day > 19)
                    {
                        day = 1;
                        month++;
                    }
                    final.Add(new SpecialDay(new BadiDate(_year, month, day), HolyDayCode.BirthBaha, SpecialDayType.HolyDay_WorkSuspended));
                }
            }

            if (typesWanted.HasFlag(SpecialDayType.HolyDay_Other))
            {
                final.Add(new SpecialDay(new BadiDate(_year, 14, 4), HolyDayCode.Covenant, SpecialDayType.HolyDay_Other));
                final.Add(new SpecialDay(new BadiDate(_year, 14, 6), HolyDayCode.AscAbdul, SpecialDayType.HolyDay_Other, SpecialTimeCode.H01));
            }

            List<SpecialDay> filteredSpecialDays = final
              .Where(sd => holyDaysWanted == HolyDayCode._NoCode_ || MatchesHolyDayCriteria(sd))
              .OrderBy(sd => sd.Date.LocalDate.DayOfYear)
              .ToList();

            bool MatchesHolyDayCriteria(SpecialDay sd)
            {
                return (!sd.DayType.HasFlag(SpecialDayType.HolyDay_WorkSuspended | SpecialDayType.HolyDay_Other)
                        && sd.DayCode.HasFlag(holyDaysWanted));
            }

            return filteredSpecialDays;
        }
    }
}
