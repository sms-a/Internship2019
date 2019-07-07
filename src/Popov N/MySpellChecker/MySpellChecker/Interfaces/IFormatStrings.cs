using System.Collections.Generic;

namespace MySpellChecker.Interfaces
{
    public interface IFormatStrings
    {
        string FormatStringToUnknown(string word);
        string FormatStringsToFamous(IEnumerable<string> words);
        string ToFormatResultString(IEnumerable<string> words);
    }
}
