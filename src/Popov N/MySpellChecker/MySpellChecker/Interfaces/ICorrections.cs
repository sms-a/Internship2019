using System.Collections.Generic;

namespace MySpellChecker.Interfaces
{
    public interface ICorrections
    {
        string Correct(string word);
        string Correct(IEnumerable<string> words);
    }
}
