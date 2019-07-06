using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySpellChecker.Interfaces;

namespace MySpellChecker
{
    public class FormatStrings: IFormatStrings
    {
        public string FormatStringToUnknown(string word)
        {
            return "{" + word + "?}";
        }

        public string FormatStringsToFinalView(IEnumerable<string> words)
        {
            string output = "{";
            if (words.Count() == 1) return words.First();
            foreach (string word in words)
            {
                output += word + " ";
            }
            return output.Trim() + "}";
        }
    }
}
