using System;
using System.Linq;
using System.Linq.Expressions;

namespace BadiNodaTime.Utility
{
  public struct CompiledExpression
  {
    public string Token { get; }
    public Func<string, object> GetValue { get; }
    public CompiledExpression(Expression<Func<string, object>> expression)
    {
      Token = "{" + expression.Parameters[0].Name + "}";
      GetValue = expression.Compile();
    }
  }
}
