namespace MySpellChecker.Interfaces
{
    public interface ICorrections
    {
        string Correct(string word);
        string Alphabet { get; set; }
    }
}
