using System.Collections.Generic;

namespace MySpellChecker.Interfaces
{
    public interface IDictionaryLogic
    {
        bool Contains(string word);
        IEnumerable<string> GetKnownWordsInDictionary(IEnumerable<string> words);
    }
}
