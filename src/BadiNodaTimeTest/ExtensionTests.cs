using Xunit;
using BadiNodaTime.Utility;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;

namespace BadiNodaTimeTest
{
  public class ExtensionTests
  {
    [Fact]
    public void TokenReplacement()
    {
      new TokenReplacer().ReplaceTokens("Test {a} {b}", new List<Expression<Func<string, object>>> {
                a => "1",
                b => "2"
            }.ToDictionary(e => e.Parameters[0].Name, e => new CompiledExpression(e)))
            .ShouldEqual("Test 1 2");
    }


    [Fact]
    public void TokenReplacementMissing()
    {
      new TokenReplacer().ReplaceTokens("Test {x} {a} {x}", new List<Expression<Func<string, object>>> {
                a => "1",
                b => "2"
            }.ToDictionary(e => e.Parameters[0].Name, e => new CompiledExpression(e)))
            .ShouldEqual("Test {x} 1 {x}");
    }
  }
}
