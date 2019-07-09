using System.Collections.Generic;

namespace MySpellChecker.Interfaces
{
    public interface IDictionaryLogic
    {
        string Alphabet { get; set; }
        bool Contains(string word);
        IEnumerable<string> GetKnownWordsInDictionary(IEnumerable<string> words);
    }
}
