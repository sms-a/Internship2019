using System;
using System.Collections.Generic;

namespace BuisnessLogic
{
    class Program
    {
        static void Main(string[] args)
        {
            var listCorrectWords = InputListWords();        //словарь корректных слов
            var checker = new Checker(listCorrectWords);
            var listWordsToBeChecked = InputListWords();    //слова, которые нужно проверить
            Output(checker, listWordsToBeChecked);
            Console.ReadKey();
        }


        /// <summary>
        /// Получает список слов, вводимых через консоль
        /// </summary>
        /// <param name="symbolInputEnd">Признак окончания ввода</param>
        /// <returns></returns>
        private static IEnumerable<string> InputListWords(string symbolInputEnd = "===")
        {
            List<string> wordsList = new List<string>();
            string input;
            do
            {
                input = Console.ReadLine();
                if (input.Length > 0)
                {
                    wordsList.AddRange(input.Split(' '));
                }
            } while (!input.EndsWith(symbolInputEnd));
            return wordsList;
        }
        /// <summary>
        /// Вывод в консоль откорректированного текста
        /// </summary>
        /// <param name="checker">Объект, проверяющий текст по словарю</param>
        /// <param name="listWordsToBeChecked">Текст для проверки в виде списка слов</param>
        private static void Output(Checker checker, IEnumerable<string> listWordsToBeChecked)
        {
            foreach (string word in listWordsToBeChecked)
            {
                Console.Write(checker.GetCorrectWord(word) + " ");
            }
        }
    }
}
