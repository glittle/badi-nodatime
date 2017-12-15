using NodaTime;
using NUnit.Framework;

namespace WondrousNodaTime.Test
{
  public static class TestHelper
  {
    public static void ShouldEqual<T>(this T input, T desired, string message = null)
    {
      Assert.AreEqual(desired, input, message);
    }

    public static string ToShortIsoDate(this WondrousDate input) {
      var iso = input.LocalDate.WithCalendar(CalendarSystem.Iso);
      return $"{iso.Year}-{iso.Month}-{iso.Day}";
    }
  }
}
