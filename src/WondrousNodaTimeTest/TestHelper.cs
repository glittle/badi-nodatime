using NodaTime;
using Xunit;

namespace WondrousNodaTime.Test
{
  public static class TestHelper
  {
    public static void ShouldEqual<T>(this T input, T desired)
    {
      Assert.Equal(desired, input);
    }

    public static string ToShortIsoDate(this WondrousDate input) {
      var iso = input.LocalDate.WithCalendar(CalendarSystem.Iso);
      return $"{iso.Year}-{iso.Month}-{iso.Day}";
    }
  }
}
