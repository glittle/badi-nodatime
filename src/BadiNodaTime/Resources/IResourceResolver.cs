namespace BadiNodaTime.Resources
{
  public interface IResourceResolver
  {
    /// <summary>
    /// Change the language from English to any other found in ResourceFiles folder.
    /// </summary>
    /// <param name="languageCode"></param>
    string Language { get; set; }



    /// <summary>
    /// Get the specified string from this resource
    /// </summary>
    /// <param name="key">The key of the resource</param>
    /// <returns></returns>
    string GetRawString(string key);
  }
}