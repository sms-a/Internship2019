using System;
using System.Collections.Generic;

namespace SpellChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "";
            List<string> dictionary = new List<string>();
            do
            {
                input = Console.ReadLine();
                if (input.Length > 0)
                {
                    dictionary.AddRange(input.Split(' '));
                }
            } while (!input.EndsWith("==="));
            var checker = new Checker(dictionary);
            List<string> text = new List<string>();
            input = "";
            do
            {
                input = Console.ReadLine();
                if (input.Length > 0)
                {
                    text.AddRange(input.Split(' '));
                }
            } while (!input.EndsWith("==="));
            foreach (string word in text)
            {
                Console.Write(checker.GetCorrectWord(word)+" ");
            }
            Console.ReadKey();
        }
    }
}
