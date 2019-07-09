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
            foreach (string corWord in dictionary)
            {
                if (Math.Abs(corWord.Length - word.Length) > 2) continue;
                if (GetLevenshteinDistance(corWord, word) == 1)
                    correctWords.Add(corWord);
            }
            if (correctWords.Count==0)
                foreach (string corWord in dictionary)
                {
                    if (Math.Abs(corWord.Length - word.Length) > 2) continue;
                    if (GetLevenshteinDistance(corWord, word) == 2)
                        correctWords.Add(corWord);
                }
            string corrWord = "";
            if (correctWords.Count == 0) return corrWord;
            if (correctWords.Count == 1) return correctWords[0];
            corrWord += "{";
            foreach (string w in correctWords)
                corrWord += w + " ";
            return corrWord.Substring(0,corrWord.Length-1) +"}";
        }
        public int GetLevenshteinDistance(string word1, string word2) 
        {
            int dist;
            int[,] m = new int[word1.Length + 1, word2.Length + 1];
            for (int i = 0; i <= word1.Length; i++)
            {
                m[i, 0] = i;
            }
            for (int j = 0; j <= word2.Length; j++)
            {
                m[0, j] = j;
            }
            for (int i = 1; i <= word1.Length; i++)
            {
                for (int j = 1; j <= word2.Length; j++)
                {
                    dist = (word1[i - 1] == word2[j - 1]) ? 0 : 2;

                    m[i, j] = Math.Min(Math.Min(m[i - 1, j] + 1,
                                             m[i, j - 1] + 1),
                                             m[i - 1, j - 1] + dist);
                }
            }
            return m[word1.Length, word2.Length];
        } 
    }}
