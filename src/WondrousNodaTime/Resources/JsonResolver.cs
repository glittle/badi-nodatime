using Newtonsoft.Json;
using System.Reflection;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json.Linq;
using System;

namespace WondrousNodaTime.Resources
{
  internal class JsonResolver
  {
    Dictionary<string, string> _resourceItems = new Dictionary<string, string>();
    List<string> _filesLoaded = new List<string>();
    string _folder;

    public JsonResolver()
    {
      LoadFiles();
    }

    private void LoadFiles()
    {
      var assembly = Assembly.GetEntryAssembly();
      //var resourceStream = assembly.M.GetManifestResourceStream("EmbeddedResource.ResourcesFiles.en.messages.json");

      _folder = Path.Combine(Path.GetDirectoryName(assembly.Location), "ResourceFiles");

      // load base language, then culture languages
      LoadLanguage("en");
      LoadLanguage(CultureInfo.CurrentCulture.Name.Substring(0, 2));
      LoadLanguage(CultureInfo.CurrentCulture.Name);
      LoadLanguage(CultureInfo.CurrentUICulture.Name.Substring(0, 2));
      LoadLanguage(CultureInfo.CurrentUICulture.Name);
    }

    private void LoadLanguage(string code)
    {
      var fileName = Path.Combine(_folder, code, "messages.json");
      if (!File.Exists(fileName) || _filesLoaded.Contains(fileName))
      {
        return;
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
    }

    /// <summary>
    /// Get the resource
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public string GetRawString(string key) {
      if (_resourceItems.ContainsKey(key)) {
        return _resourceItems[key];
      }
      return null;
    }
  }
}

