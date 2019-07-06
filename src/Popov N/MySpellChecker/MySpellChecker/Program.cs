using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySpellChecker
{ 

    // Test Class for ref//
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("test");
            string input;
            string Words = null;
            List<string> spellsArrayList = null;
            List<string> wordsArrayList = null;
         
            input = Console.ReadLine();
            char[] split = new[] { ' ' };
            if (input.Contains("===") && (input.Length - 3 == input.LastIndexOf("===")))
            {
                input = input.Replace("===", "");
                Words = input;
                wordsArrayList = input.Split(split, StringSplitOptions.RemoveEmptyEntries).ToList();

            }
            input = Console.ReadLine();
            if (input.Contains("===") && (input.Length - 3 == input.LastIndexOf("===")))
            {
                input = input.Replace("===", "");
                spellsArrayList = input.Split(split, StringSplitOptions.RemoveEmptyEntries).ToList();

            }

            Console.ReadKey();

        }




    }
}
