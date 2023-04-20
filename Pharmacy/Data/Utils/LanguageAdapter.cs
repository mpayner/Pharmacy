using Microsoft.EntityFrameworkCore;

namespace Pharmacy.Data.Utils
{
    public class LanguageAdapter
    {
        public static readonly Dictionary<string, string> converter = new Dictionary<string, string>()
        {
            {"а", "a"}, {"б", "b"}, {"в", "v"}, {"г", "h"}, {"ґ", "g"},
            {"д", "d"}, {"е", "e"}, {"є", "ye"}, {"ж", "zh"}, {"з", "z"},
            {"и", "y"}, {"і", "i"}, {"ї", "yi"}, {"й", "y"}, {"к", "k"},
            {"л", "l"}, {"м", "m"}, {"н", "n"}, {"о", "o"}, {"п", "p"},
            {"р", "r"}, {"с", "s"}, {"т", "t"}, {"у", "u"}, {"`",""},
            {"ф", "f"},{"х", "kh"}, {"ц", "ts"}, {"ч", "ch"},{"ь", ""},
            {"ш", "sh"}, {"щ", "shch"},{"ю", "yu"}, {"я", "ya"}
        };

        public static string Transliterate(string value)
        {
            

            value = value.ToLower();
            foreach (KeyValuePair<string, string> pair in converter)
            {
                value = value.Replace(pair.Key, pair.Value);
            }
            value = System.Text.RegularExpressions.Regex.Replace(value, "\\s", "-");
            value = System.Text.RegularExpressions.Regex.Replace(value, "[-]+", "-");
            value = value.Trim('-');

            return value;
        }
    }
}
