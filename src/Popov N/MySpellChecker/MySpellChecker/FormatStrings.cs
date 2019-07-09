using System.Collections.Generic;
using System.Linq;
using MySpellChecker.Interfaces;

namespace MySpellChecker
{
    public class FormatStrings: IFormatStrings
    {
        public string FormatStringToUnknown(string word)
        {
            return "{" + word + "?}";
        }

        public string FormatStringsToFamous(IEnumerable<string> words)
        {
            string output = "{";
            if (words.Count() == 1) return words.First();
            foreach (string word in words)
            {
                output += word + " ";
            }
            return output.Trim() + "}";
        }

        public string ToFormatResultString(IEnumerable<string> words)
        {
            string result = "";
            foreach (string word in words)
                result += word + " ";
            return result.Trim(' ');
        }
    }
}
