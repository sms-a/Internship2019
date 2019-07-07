using System;
using System.Collections.Generic;
using System.Text;

namespace SpellChecker
{
    public class Checker
    {
        List<string> dictionary;
        public Checker(List<string> dictionary)
        {
            this.dictionary = dictionary;
        }
        public string GetCorrectWord(string word)
        {
            if (dictionary.Contains(word.ToLower())) return word;
            string correctWord = FindWordsWihOneEdit(word);
            if (correctWord.Length > 0) return correctWord;
            return IncorrectWord(word);
        }
        string IncorrectWord(string word)
        {
            return "{" + word + "?}";
        }
        List <string> GetWordsWithOneEdit(string word)
        {
            List<string> wordsList = new List<string>();
            for (int i = 0; i < word.Length; i++)
            {
                string newWord = word.Substring(0, i) + word.Substring(i + 1, word.Length - i-1);
                if (dictionary.Contains(newWord)&&!wordsList.Contains(newWord)) wordsList.Add(newWord);
            }
            string alpa = "abcdefghijklmnopqrstuvwxyz";
            for (int i = 0; i <= word.Length; i++)
            {
                foreach (char letter in alpa)
                {
                    string newWord = word.Substring(0, i) + letter+word.Substring(i, word.Length - i);
                    if (dictionary.Contains(newWord) && !wordsList.Contains(newWord)) wordsList.Add(newWord);
                }
            }
            return wordsList;
        }
        string FindWordsWihOneEdit(string word)
        {
            string correctWord = "";
            List<string> wordsWithOneEdit = GetWordsWithOneEdit(word);
            if (wordsWithOneEdit.Count == 0) return correctWord;
            if (wordsWithOneEdit.Count > 1)
            {
                correctWord = "{ ";
                foreach (string w in dictionary)
                    if (wordsWithOneEdit.Contains(w))
                        correctWord += w + " ";
                correctWord += "}";
                return correctWord;
            }
            return correctWord = wordsWithOneEdit[0];           
        }
    }}
