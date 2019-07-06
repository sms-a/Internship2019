using System.Collections.Generic;

namespace MySpellChecker.Interfaces
{
    public interface IFormatStrings
    {
        string FormatStringToUnknown(string word);
        string FormatStringsToFinalView(IEnumerable<string> words);
    }
}
