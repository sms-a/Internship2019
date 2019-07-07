using System.Collections.Generic;
using MySpellChecker.Interfaces;

namespace MySpellChecker
{
    static class Program
    {
        private static string Alphabet;
        private static string inputDict = "Введите словарь:";
        private static string inputWords = "Введите слова для проверки:";
        private static string outputResult = "Результирующая строка:";


        static void Main(string[] args)
        {
            IOStrings ioStrings = new IOStrings();
            Alphabet = ioStrings.GetAlphabet();

            ioStrings.WriteLine(inputDict);
            IEnumerable<string> inputWordsEnumerable = ioStrings.ReadLine();
            ioStrings.WriteLine(inputWords);
            IEnumerable<string> inputEnumerable = ioStrings.ReadLine();

            IFormatStrings formatStrings = new FormatStrings();
            IDictionaryLogic dictionaryLogic = new DictionaryLogic(inputWordsEnumerable,Alphabet);
            ICorrections correctionsLogic = new CorrectionsLogic(dictionaryLogic, formatStrings);

            ioStrings.WriteLine(outputResult);
            ioStrings.WriteLine(correctionsLogic.Correct(inputEnumerable));
            
            ioStrings.Pause();
        }
        //Console.WriteLine("test");
        //string input;
        //string Words = null;
        //List<string> spellsArrayList = null;
        //List<string> wordsArrayList = null;
        //input = Console.ReadLine();
        //char[] split = new[] { ' ' };
        //if (input.Contains("===") && (input.Length - 3 == input.LastIndexOf("===")))
        //{
        //    input = input.Replace("===", "");
        //    Words = input;
        //    wordsArrayList = input.Split(split, StringSplitOptions.RemoveEmptyEntries).ToList();
        //}
        //input = Console.ReadLine();
        //if (input.Contains("===") && (input.Length - 3 == input.LastIndexOf("===")))
        //{
        //    input = input.Replace("===", "");
        //    spellsArrayList = input.Split(split, StringSplitOptions.RemoveEmptyEntries).ToList();
        //}
    }
}
