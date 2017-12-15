using NUnit.Framework;
using WondrousNodaTime.Utility;

namespace WondrousNodaTime.Test
{
  public class ExtensionTests
  {
    [Test]
    public void TokenReplacement()
    {
      "Test {a} {b}".ReplaceTokens(
                a => "1",
        b => "2"
).ShouldEqual("Test 1 2");
    }
  }
}
