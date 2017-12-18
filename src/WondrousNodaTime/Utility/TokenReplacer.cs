using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace WondrousNodaTime.Utility
{
  public class TokenReplacer
  {
    // better options?
    // - SmartFormat.NET
    // - IT2media.Extensions.String
    // - StringTokenFormatter 
    // None of the above support the same selection of frameworks that we support, so can't be used




    ///// <summary>
    ///// Very simple token replacement, with lazy evaluation
    ///// </summary>
    ///// <param name="template"></param>
    ///// <param name="availableReplacements"></param>
    ///// <returns></returns>
    //public string ReplaceTokens1(string template, Dictionary<string, CompiledExpression> availableReplacements)
    //{
    //  var sb = new StringBuilder(template);

    //  // scan all possible replacements to see if any of them are in this template
    //  foreach (var kvp in availableReplacements)
    //  {
    //    // token like: {x}
    //    string token = kvp.Value.Token;

    //    if (template.Contains(token))
    //    {
    //      var value = kvp.Value.GetValue(kvp.Key);

    //      sb.Replace(token, value != null ? value.ToString() : token);
    //    }
    //  }

    //  return sb.ToString();
    //}

    /// <summary>
    /// Very simple token replacement, with lazy evaluation
    /// </summary>
    /// <param name="template"></param>
    /// <param name="availableReplacements"></param>
    /// <returns></returns>
    public string ReplaceTokens(string template, IDictionary<string, CompiledExpression> availableReplacements)
    {
      return Regex.Replace(template, @"{(\w+)}", (token) =>
      {
        var key = token.Groups[1].Value;
        if (availableReplacements.ContainsKey(key))
        {
          var value = availableReplacements[key].GetValue(key);
          if (value != null)
          {
            return value.ToString();
          }
        }
        return token.Groups[0].Value;
      });
    }
  }
}
