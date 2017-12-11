using NUnit.Framework;

namespace WondrousNodaTime.Test
{
  public static class TestHelper
  {
    public static void ShouldEqual<T>(this T input, T desired, string message = null)
    {
      Assert.AreEqual(desired, input, message);
    }
  }
}
