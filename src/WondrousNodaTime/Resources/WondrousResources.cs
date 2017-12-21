using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
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
  public class WondrousResources
  {
    IResourceResolver _customResolver;
    IResourceResolver _defaultResolver;

    Dictionary<string, string[]> _parsedLists;

    public const string PrefixIfInvalid = "[?";
    private static ServiceProvider _provider;
    private static ServiceCollection _serviceCollection;

    private WondrousResources()
    {
      //TODO move this to a better place?
      //TODO remove hard coded dependency?
      if (_serviceCollection == null)
      {
        _serviceCollection = new ServiceCollection();
        _serviceCollection.AddScoped<IResourceResolver, JsonResolver>();
        _provider = _serviceCollection.BuildServiceProvider();
      }
    }


    /// <summary>
    /// Source of translated values specific to this Wondrous Calendar library.
    /// </summary>
    /// <param name="languageCode">Force a particular language code. 
    /// If not specified, will use the <see cref="CultureInfo.CurrentCulture"/> and <see cref="CultureInfo.CurrentUICulture"/>.
    /// In this implementation, the English wording will be used if no cultural translation is provided.
    /// Additional languages can be added to the ResourceFiles folder by creating a folder whose name matches the language code
    /// and providing a "messages.json" file in it where the "message" values are translated. 
    /// </param>
    /// <param name="customResolver">Provide an alternative mechanism to get the resources normally found in the JSON files in ResourceFile.</param>
    /// <remarks>The custom resolver should return null if it cannot provide a value for the key.</remarks>
    public WondrousResources(string languageCode = null, IResourceResolver customResolver = null) : this()
    {
      _defaultResolver = _provider.GetRequiredService<IResourceResolver>();
      if (languageCode != null)
      {
        _defaultResolver.Language = languageCode;
        if (_parsedLists != null) _parsedLists.Clear();
      }
      _customResolver = customResolver;
    }

    public string Language => _defaultResolver.Language;

    public string GetString(string key)
    {
      var raw1 = _customResolver == null ? null : _customResolver.GetRawString(key);

      var raw2 = raw1 ?? _defaultResolver.GetRawString(key);
      return raw2 ?? PrefixIfInvalid + key + "]";
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
        if (s.StartsWith(PrefixIfInvalid))
        {
          return s;
        }
        list = s == null ? new string[0] : s.Split(',');
        _parsedLists.Add(key, list);
      }
      if (list.Length <= index)
      {
        return "";
      }
      return list[index];
    }

  }

}
