using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySpellChecker.Interfaces;

namespace MySpellChecker
{
    public class IOStrings:IInputOutput
    {
        private string _separator = "===";
        private string _alphabet = "abcdefghijklmnopqrstuvwxyz";

        public string GetAlphabet()
        {
            return _alphabet;
        }

        public void WriteLine(string str)
        {
            if (str == null)
            {
                throw new ArgumentNullException();
            }
            Console.WriteLine(str);
        }

        public void Pause()
        {
            Console.ReadKey();
        }

        public IEnumerable<string> ReadLine()
        {
            IEnumerable<string> returnList = new List<string>();

            bool exit = false;
            while (!exit)
            {
                string str = Console.ReadLine();
                if (str != null)
                {
                    if (str.Contains(_separator)) exit = true;
                    string[] words = str.Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries);
                    returnList = returnList.Concat(words.ToList());
                }
            }

            return returnList;
        }
    }
}
