using Newtonsoft.Json;
using System.Reflection;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json.Linq;
using System;

namespace BadiNodaTime.Resources
{
  internal class JsonResolver : IResourceResolver
  {
    Dictionary<string, string> _resourceItems = new Dictionary<string, string>();
    List<string> _filesLoaded = new List<string>();
    string _folder;
    string _forcedLanguageCode;
    bool _fileLoadAttempted = false;

    public string Language
    {
      get => _forcedLanguageCode ?? "en";
      set
      {
        _forcedLanguageCode = value;
        LoadFiles();
      }
    }

    private void LoadFiles()
    {
      _fileLoadAttempted = true;
      _resourceItems.Clear();
      _filesLoaded.Clear();

      var assembly = Assembly.GetAssembly(GetType());

      _folder = Path.Combine(Path.GetDirectoryName(assembly.Location), "ResourceFiles");

      // load base language, then culture languages
      LoadLanguage("en");

      if (_forcedLanguageCode != null)
      {
        LoadLanguage(_forcedLanguageCode, true);
        return;
      }

      LoadLanguage(CultureInfo.CurrentCulture.Name.Substring(0, 2));
      LoadLanguage(CultureInfo.CurrentCulture.Name);

      LoadLanguage(CultureInfo.CurrentUICulture.Name.Substring(0, 2));
      LoadLanguage(CultureInfo.CurrentUICulture.Name);
    }

    /// <summary>
    /// Load the language resource. Any resource or key not found will default to the English resource.
    /// </summary>
    /// <param name="code">Code 2 or 5 long matching folder names in the ResourceFiles folder. E.g. "en" or "en-US"</param>
    /// <param name="getFirstCulturalVersion">If a 2 letter code is provided, but there is no matching "2 letter" resource file, attempt 
    /// to load the first cultural resource file available. E.g. if "pt" is requested, but the only file is "pt_PT", then use it.</param>
    /// <returns></returns>
    private bool LoadLanguage(string code, bool getFirstCulturalVersion = false)
    {
      var fileName = Path.Combine(_folder, code, "messages.json");
      if (!File.Exists(fileName))
      {
        if (code.Length == 2 && getFirstCulturalVersion)
        {
          var folders = Directory.GetDirectories(_folder, code + "*");
          if (folders.Length > 0)
          {
            return LoadLanguage(folders[0].Replace(_folder + "\\", ""));
          }
        }
        return false;
      }
      if (_filesLoaded.Contains(fileName))
      {
        return true;
      }

      _filesLoaded.Add(fileName);

      var allTexts = File.ReadAllText(fileName);

      var dict = JsonConvert.DeserializeObject<Dictionary<string, JObject>>(allTexts);
      foreach (var kvp in dict)
      {
        var value = kvp.Value["message"]?.Value<String>();
        if (value != null)
        {
          _resourceItems[kvp.Key] = value;
        }
      }

      return true;
    }

    /// <summary>
    /// Get the resource
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public string GetRawString(string key)
    {
      if (!_fileLoadAttempted)
      {
        LoadFiles();
      }

      if (_resourceItems.ContainsKey(key))
      {
        return _resourceItems[key];
      }
      return null;
    }
  }
}

