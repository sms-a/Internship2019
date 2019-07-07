using System;
using System.Collections.Generic;

namespace SpellChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string input = "";
            List<string> dictionary = new List<string>();
            do
            {
                if (input.Length > 0)
                {
                    dictionary.AddRange(input.Split(' '));
                }
                input = Console.ReadLine();
            } while (!input.Equals("==="));
            var checker = new Checker(dictionary);
            List<string> text = new List<string>();
            input = "";
            do
            {
                if (input.Length > 0)
                {
                    text.AddRange(input.Split(' '));
                }
                input = Console.ReadLine();
            } while (!input.Equals("==="));
            foreach (string word in text)
            {
                Console.WriteLine(checker.GetCorrectWord(word));
            }
        }
    }
}
