using System.Collections.Generic;

namespace MySpellChecker.Interfaces
{
    public interface IInputOutput
    {
        string GetAlphabet();
        void WriteLine(string str);
        void Pause();
        IEnumerable<string> ReadLine();
    }
}
