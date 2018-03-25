using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using BadiNodaTime.Resources;
using System.Globalization;

namespace BadiNodaTime.Utility
{
  public class DateTemplateProcessor
  {
    readonly BadiResources _resolver;
    readonly TokenReplacer _tokenReplacer;

    public DateTemplateProcessor() : this(new BadiResources())
    {
    }

    public DateTemplateProcessor(BadiResources resolver)
    {
      _resolver = resolver;
      _tokenReplacer = new TokenReplacer();
    }

    /// <summary>
    /// Generate a string for this BadiDate based on the template given.
    /// </summary>
    /// <param name="date"></param>
    /// <param name="template"></param>
    /// <returns></returns>
    public string FillTemplate(BadiDate date, string template = null)
    {
      if (string.IsNullOrWhiteSpace(template))
      {
        template = "{yearOfEra}-{month}-{day}";
      }

      string answer1 = template;
      string answer2;
      bool repeat;

      do
      {
        answer2 = _tokenReplacer.ReplaceTokens(answer1, AvailableReplacements(date));

        repeat = answer2.Contains("{") && answer2 != answer1;

        if (repeat)
        {
          answer1 = answer2;
        }
      } while (repeat);

      return answer2;
    }

    /// <summary>
    /// A listing of available replacement tokens, with their values for the date provided
    /// </summary>
    public IEnumerable<string> AvailableTokens(BadiDate testDate = null, string template = null)
    {
      testDate = testDate ?? new BadiDate();
      template = template ?? "<dt>{{{0}}}</dt><dd>{1}</dd>";

      var dict = AvailableReplacements(testDate);
      var keys = dict.Keys;

      // test each for compound keys
      foreach (var key in keys)
      {
        var value = dict[key].GetValue(key);

        if (value.GetType().IsGenericType)
        {
          foreach (var minorKey in ((Dictionary<string, CompiledExpression>)value).Keys)
          {
            string compoundKey = $"{key}.{minorKey}";
            yield return String.Format(template, compoundKey, testDate.ToString($"{{{compoundKey}}}"));
          }
        }
        else
        {
          yield return String.Format(template, key, testDate.ToString($"{{{key}}}"));
        }
      }
    }

    /// <summary>
    /// Structured using Expressions to avoid having to pre-calculate every single option for each call to format a date.
    /// Expressions are pre-compiled.
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    private Dictionary<string, CompiledExpression> AvailableReplacements(BadiDate date)
    {
      var g = date.WithCalendar(CalendarSystem.Gregorian);

      return new List<Expression<Func<string, object>>> {

        day => date.Day,
        day00 => date.Day.Pad00(),
        day_ordinal => _resolver.GetListItem("OrdinalNames", date.Day),
        day_meaning => _resolver.GetListItem("MonthMeaning", date.Day),
        day_arabic => _resolver.GetListItem("MonthArabic", date.Day),

        weekday => date.Weekday,
        weekday00 => date.Weekday.Pad00(),
        weekday_ordinal => _resolver.GetListItem("OrdinalNames", date.Weekday),
        weekday_meaning => _resolver.GetListItem("WeekdayMeaning", date.Weekday),
        weekday_arabic => _resolver.GetListItem("WeekdayArabic", date.Weekday),

        month => date.Month,
        month00 => date.Month.Pad00(),
        month_ordinal => _resolver.GetListItem("OrdinalNames", date.Month),
        month_meaning => _resolver.GetListItem("MonthMeaning", date.Month),
        month_arabic => _resolver.GetListItem("MonthArabic", date.Month),

        element => date.Element,
        element00 => date.Element.Pad00(),
        element_meaning => _resolver.GetListItem("Elements", date.Element),

        yearOfEra => date.YearOfEra,
        yearOfEra00 => date.YearOfEra.Pad00(),

        yearOfUnity => date.YearOfUnity,
        yearOfUnity00 => date.YearOfUnity.Pad00(),
        yearOfUnity_ordinal => _resolver.GetListItem("OrdinalNames", date.YearOfUnity),
        yearOfUnity_meaning => _resolver.GetListItem("YearOfUnityMeaning", date.YearOfUnity),
        yearOfUnity_arabic => _resolver.GetListItem("YearOfUnityArabic", date.YearOfUnity),

        unity => date.Unity,
        unity00 => date.Unity.Pad00(),
        unity_ordinal => _resolver.GetListItem("OrdinalNames", date.Unity),

        allThings => date.AllThings,
        allThings00 => date.AllThings.Pad00(),
        allThings_ordinal => _resolver.GetListItem("OrdinalNames", date.AllThings),

        gregorian => new List<Expression<Func<string, object>>> {
          
          // basic options... for other formats, use standard .NET or Noda Time format features

          day => g.Day,
          day00 => g.Day.Pad00(),

          month => g.Month,
          month00 => g.Month.Pad00(),
          month_latin_short => g.ToString("MMM", CultureInfo.CreateSpecificCulture(_resolver.Language)),
          month_latin_long => g.ToString("MMMM", CultureInfo.CreateSpecificCulture(_resolver.Language)),

          year => g.Year,

        }.ToDictionary(e => e.Parameters[0].Name, e => new CompiledExpression(e)),



      }.ToDictionary(e => e.Parameters[0].Name, e => new CompiledExpression(e));
    }
  }
}
