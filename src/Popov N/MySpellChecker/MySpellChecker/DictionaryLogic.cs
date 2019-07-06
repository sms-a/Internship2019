using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MySpellChecker.Interfaces;

namespace MySpellChecker
{
    public class DictionaryLogic : IDictionaryLogic
    {
        private readonly Dictionary<string, int> _dictionary;

        public DictionaryLogic(IEnumerable<string> sample)
        {
            _dictionary = sample.Select(w => w) 
                .GroupBy(w => w)
                .ToDictionary(w => w.Key, w => w.Count());
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
