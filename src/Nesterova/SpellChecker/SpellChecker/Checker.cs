using System;
using System.Collections.Generic;
using System.Text;

namespace SpellChecker
{
    public class Checker
    {
        List<string> dictionary;
        public Checker (List<string> dictionary)
        {
            this.dictionary = dictionary;
        }
        public string GetCorrectWord(string word)
        {
            if (dictionary.Contains(word.ToLower())) return word;
            return IncorrectWord(word);
        }
        string IncorrectWord(string word)
        {
            return "{" + word + "?}";
        }
    }
}
