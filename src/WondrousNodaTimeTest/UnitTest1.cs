using System;
using Xunit;

namespace WondrousNodaTimeTest
{
  public class UnitTest1
  {
    [Theory]
    [InlineData(1,2)]
    public void Test1(int a, int b)
    {
      Assert.Equal(a * 2, b);
    }
  }
}
