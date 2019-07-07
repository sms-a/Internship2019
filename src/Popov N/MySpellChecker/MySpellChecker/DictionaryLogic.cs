using System.Collections.Generic;
using System.Linq;
using MySpellChecker.Interfaces;

namespace MySpellChecker
{
    public class DictionaryLogic : IDictionaryLogic
    {
        private readonly Dictionary<string, int> _dictionary;

        public string Alphabet { get; set; }

        public DictionaryLogic(IEnumerable<string> wordsToDictionary, string alphabet)
        {
            _dictionary = wordsToDictionary.Select(w => w).GroupBy(w => w).ToDictionary(g => g.Key, g => g.Count());
            Alphabet = alphabet;
        }

        public bool Contains(string word)
        {
            return _dictionary.ContainsKey(word);
        }

        public IEnumerable<string> GetKnownWordsInDictionary(IEnumerable<string> words)
        {
            return words.Where(Contains);
        }
    }
}
