using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace BadiNodaTime.Utility
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
      return Regex.Replace(template, @"{([\w\.]+)}", (token) =>
      {
        var tokenContent = token.Groups[1].Value;

        var parts = tokenContent.Split('.');
        var majorKey = parts[0];

        if (availableReplacements.ContainsKey(majorKey))
        {
          var value = availableReplacements[majorKey].GetValue(majorKey);
          if (value != null)
          {
            if (parts.Length == 2 && value.GetType().IsGenericType)
            {
              var minorKey = parts[1];
              return ((Dictionary<string, CompiledExpression>)value)[minorKey].GetValue(minorKey).ToString();
            }

            return value.ToString();
          }
        }

        // not found? return the entire token
        return token.Groups[0].Value;
      });
    }
  }
}
