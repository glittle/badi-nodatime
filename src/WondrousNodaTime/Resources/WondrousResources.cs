using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace WondrousNodaTime.Resources
{
  /// <summary>
  /// We need to have localized resources to show month names, etc.
  /// As of Dec 2017, this project supports .NET 4x and .NET Core 1.3. 
  ///   - .RESX files do not work correctly in .NET Core 1.3
  ///   - IStringLocalizer does not work with .NET 4x
  /// Until the tech settles, we will use a simple JSON structure.
  /// We also support optional callbacks to the host application to dynamically provide translation values.
  /// </summary>
  internal class WondrousResources
  {
    Func<string, string> _customResolver;
    JsonResolver _defaultResolver;

    Dictionary<string, string[]> _parsedLists;

    /// <summary>
    /// Source of translated values
    /// </summary>
    public WondrousResources()
    {
      _defaultResolver = new JsonResolver();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="customResolver"></param>
    public WondrousResources(Func<string, string> customResolver) : this()
    {
      _customResolver = customResolver;
    }

    public string GetString(string key)
    {
      var raw1 = _customResolver == null ? null : _customResolver(key);
      var raw2 = raw1 ?? _defaultResolver.GetRawString(key);
      return raw2 ?? key;
    }

    public string GetListItem(string key, int index)
    {
      if (_parsedLists == null)
      {
        _parsedLists = new Dictionary<string, string[]>();
      }
      string[] list;
      if (_parsedLists.ContainsKey(key))
      {
        list = _parsedLists[key];
      }
      else
      {
        var s = GetString(key);
        list = s == null ? new string[0] : s.Split(',');
        _parsedLists.Add(key, list);
      }
      if (list.Length <= index)
      {
        return list[index];
      }
      return "";
    }

  }

}
