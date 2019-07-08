using System;
using System.Collections.Generic;
using System.Text;

namespace SpellChecker
{
    public class Checker
    {
        string alpa = "";
        List<string> dictionary;
        public Checker(List<string> dictionary)
        {
            this.dictionary = dictionary;
            GenerateAlpha();
        }

        private void GenerateAlpha()
        {
            foreach (string word in dictionary)
                for (int i = 0; i < word.Length; i++)
                    if (!alpa.Contains(word[i]))
                        alpa += word[i];
        }

        public string GetCorrectWord(string word)
        {
            if (word.Equals("===")) return "";
            if (word.Length > 50) return word;
            if (dictionary.Contains(word)) return word;
            string correctWord = FindWordsWihEdits(word);
            if (correctWord.Length > 0) return correctWord;
            return IncorrectWord(word);
        }
        string IncorrectWord(string word)
        {
            return "{" + word + "?}";
        }
       
        string FindWordsWihEdits(string word)
        {
            List<string> correctWords = new List<string>();
            List<string> wordsWithOneEdit = GenerateWordsWithOneEdit(word);
            foreach (string w in dictionary)
                if (wordsWithOneEdit.Contains(w))
                    correctWords.Add(w);
            if (correctWords.Count < 1) {
                List<string> wordsWithTwoEdits = GenerateWordWithTwoEdits(wordsWithOneEdit);
                foreach (string w in dictionary)
                    if (wordsWithTwoEdits.Contains(w))
                        correctWords.Add(w);
            }
            string corrWord = "";
            if (correctWords.Count == 0) return corrWord;
            if (correctWords.Count == 1) return corrWord = correctWords[0];
            corrWord += "{";
            foreach (string w in correctWords)
                corrWord += w + " ";
            return corrWord.Substring(0,corrWord.Length-1) +"}";
        }
        List<string> GenerateWordsWithOneEdit(string word)
        {
            List<string> wordsWithOneEdit = new List<string>();
            for (int i = 0; i < word.Length; i++)
            {
                string newWord = word.Substring(0, i) + word.Substring(i + 1, word.Length - i - 1);
                if (!wordsWithOneEdit.Contains(newWord)) wordsWithOneEdit.Add(newWord);
            }
            for (int i = 0; i <= word.Length; i++)
            {
                foreach (char letter in alpa)
                {
                    string newWord = word.Substring(0, i) + letter + word.Substring(i, word.Length - i);
                    if (!wordsWithOneEdit.Contains(newWord)) wordsWithOneEdit.Add(newWord);
                }
            }
            return wordsWithOneEdit;
        }
        List<string> GenerateWordWithTwoEdits(List<string> wordsWithOneEdit)
        {
            List<string> wordsWithTwoEdits = new List<string>();
            foreach(string word in wordsWithOneEdit)
            {
                for (int i = 0; i < word.Length; i++)
                {
                    string newWord = word.Substring(0, i) + word.Substring(i + 1, word.Length - i - 1);
                    if (!wordsWithTwoEdits.Contains(newWord)) wordsWithTwoEdits.Add(newWord);
                }
                for (int i = 0; i <= word.Length; i++)
                {
                    foreach (char letter in alpa)
                    {
                        string newWord = word.Substring(0, i) + letter + word.Substring(i, word.Length - i);
                        if (!wordsWithTwoEdits.Contains(newWord)) wordsWithTwoEdits.Add(newWord);
                    }
                }
            }
            return wordsWithTwoEdits;
        }
    }}
