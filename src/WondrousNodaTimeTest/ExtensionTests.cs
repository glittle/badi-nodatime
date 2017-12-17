using Xunit;
using WondrousNodaTime.Utility;

namespace WondrousNodaTimeTest
{
  public class ExtensionTests
  {
    [Fact]
    public void TokenReplacement()
    {
      "Test {a} {b}".ReplaceTokens(
                a => "1",
                b => "2"
          ).ShouldEqual("Test 1 2");
    }
  }
}
