using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WondrousNodaTime.Utility
{
  internal class Checks
  {
    public static void EnsureIsWondrousCalendar(string paramName, LocalDate date)
    {
      if (date.Calendar != CalendarSystem.Wondrous)
      {
        throw new ArgumentException("Can only be used with a LocalDate with the Wondrous calendar system", paramName);
      }
    }
  }
}
