using System;
using System.Collections.Generic;
using System.Text;

namespace BuisnessLogic
{
    public class Checker
    {
        private IEnumerable<string> listCorrectWords;
        private int maxWordLenth;
        private int maxDistanceBetweenWords;
        private string symbolInputEnd;
        public Checker(IEnumerable<string> listCorrectWords, int maxWordLenth=50, int maxDistanceBetweenWords=2, string symbolInputEnd="===")
        {
            this.listCorrectWords = listCorrectWords;
            this.maxDistanceBetweenWords = maxDistanceBetweenWords;
            this.maxWordLenth = maxWordLenth;
            this.symbolInputEnd = symbolInputEnd;
            
        }
        /// <summary>
        /// По имеющемуся слову, поступающему на проверку, выдает корректное слово из списка 
        /// правильных слов (словаря), либо перечень таких слов в соответствующем заданию 
        /// формате: {слово1, слово2, ...}
        /// Проверка производится по возрастанию дистанции Левентштейна между проверяемым
        /// словом и словом из словаря от нуля (слова идентичны) до максимального допустимого
        /// условием задачи значения. Дистанция Левенштейна показывает, сколько правок 
        /// необходимо для преобразования одного слова в другое. Правкой называются операции
        /// добавления буквы и удаления буквы из слова.
        /// Если слово не прошло проверку, объявляет его некорректным
        /// </summary>
        /// <param name="word">Проверяемое слово</param>
        /// <returns>Откорректированное слово</returns>
        public string GetCorrectWord(string word)
        {
            if (word.Equals(symbolInputEnd)) return string.Empty;
            if (word.Length > maxWordLenth) return word;
            for (int distance=0; distance<=maxDistanceBetweenWords; distance++)
            {
                var correctWord = FindWordsWithEdits(word, distance);
                if (correctWord.Length > 0) return correctWord;
            }

            return IncorrectWord(word);
        }
        private string IncorrectWord(string word)
        {
            return "{" + word + "?}";
        }
        /// <summary>
        /// Находит в словаре слово(а), подходящее для замены проверяемого слова. 
        /// Возвращает его (их) представление в соответствующем задаче формате
        /// </summary>
        /// <param name="word">Проверяемое слово</param>
        /// <param name="distsance">Дистанция Левенштейна между проверяемым словом
        /// и словом из словаря, при которой проверяемое слово может считаться 
        /// корректным (дистанция Левенштейна -
        /// https://dic.academic.ru/dic.nsf/ruwiki/901457) </param>
        /// <returns>Строковое представление откорректированного слова (или слов),
        /// если проверяемое слово можно откорректировать</returns>
        private string FindWordsWithEdits(string word, int distsance)
        {
            List<string> correctWords = new List<string>();
            foreach (string corWord in listCorrectWords)
            {
                if (Math.Abs(corWord.Length - word.Length) > 2) continue;
                if (GetLevenshteinDistance(corWord, word) == distsance)
                    correctWords.Add(corWord);
            }
            return GetFormattedString(correctWords);
        }
        /// <summary>
        /// Из списка слов формирует строку в соответствии с заданием:
        /// - если слово одно, строка состоит из одного этого слова
        /// - если слов нет, строка пустая
        /// - если слов несколько: слово1, слово2, строка имеет вид: {слово1, 
        /// слово2}
        /// </summary>
        /// <param name="wordsList">Список слов</param>
        /// <returns>Строковое представление списка слов</returns>
        private string GetFormattedString(List<string> wordsList) {
            string formattedString = string.Empty;
            if (wordsList.Count == 0) return formattedString;
            if (wordsList.Count == 1) return wordsList[0];
            formattedString += "{";
            foreach (string word in wordsList)
                formattedString += word + " ";
            return formattedString.Substring(0, formattedString.Length - 1) + "}";
        }
        /// <summary>
        /// Находит дистанцию Левенштейна между двумя словами, опираясь на 
        /// алгоритм Вагнера — Фишера (дистанция Левенштейна - 
        /// https://dic.academic.ru/dic.nsf/ruwiki/901457, алгоритм
        /// Вагнера-Фишера - http://algolist.manual.ru/search/lcs/vagner.php)
        /// </summary>
        private int GetLevenshteinDistance(string word1, string word2) 
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
 