using System.Collections.Generic;
using MySpellChecker;
using MySpellChecker.Interfaces;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class LogicTests
    {
        private IFormatStrings _formatStrings;
        private IDictionaryLogic _dictionaryLogic;
        private ICorrections _correctionsLogic;
        private string _alphabetUS = "abcdefghijklmnopqrstuvwxyz";

        [SetUp]
        public void Init()
        {
            _formatStrings = new FormatStrings();
        }

        [Test]
        public void OutputTrueString()
        {
            List<string> inputDictionary = new List<string>(){ "rain", "spain", "plain", "plaint", "pain", "main", "mainly", "the", "in", "on", "fall", "falls", "his", "was"};
            List<string> wordsArrayList = new List<string>() { "hte", "rame", "in", "pain", "fells", "mainy", "oon", "teh", "lain", "was", "hints", "pliant" };
            _dictionaryLogic = new DictionaryLogic(inputDictionary, _alphabetUS);
            _correctionsLogic = new CorrectionsLogic(_dictionaryLogic,_formatStrings);

            string output = "";
            foreach (string s in wordsArrayList)
            {
                output += _correctionsLogic.Correct(s)+" ";
            }
            
            Assert.That(output.Trim(' '), Is.EqualTo("the {rame?} in pain falls {main mainly} on the plain was {hints?} plaint"));
        }

        [Test]
        [TestCase("srame")]
        [TestCase("warts")]
        [TestCase("wastr")]
        [TestCase("etmain")]
        public void ReturnAnUnknownWord(string wordUnknown)
        {
            List<string> inputDictionary = new List<string>() { "rain", "spain", "plain", "plaint", "pain", "main", "mainly", "the", "in", "on", "fall", "falls", "his", "was" };
            _dictionaryLogic = new DictionaryLogic(inputDictionary, _alphabetUS);
            _correctionsLogic = new CorrectionsLogic(_dictionaryLogic, _formatStrings);

            string testString = _correctionsLogic.Correct(wordUnknown);

            Assert.AreEqual("{"+wordUnknown+"?}", testString);
        }

        [Test]
        public void ReturnAnSomeWords()
        {
            List<string> inputDictionary = new List<string>() {  "spain", "plaint", "paint"};
            string word = "ptain";
            _dictionaryLogic = new DictionaryLogic(inputDictionary, _alphabetUS);
            _correctionsLogic = new CorrectionsLogic(_dictionaryLogic, _formatStrings);

            string testString = _correctionsLogic.Correct(word);

            Assert.AreEqual("{spain paint}", testString);
        }

        [Test]
        [TestCase("spn")]
        [TestCase("pnt")]
        [TestCase("int")]
        public void InsertsDoubleWordNotFound(string word)
        {
            List<string> inputDictionary = new List<string>() { "spain", "plaint", "paint" };
            _dictionaryLogic = new DictionaryLogic(inputDictionary, _alphabetUS);
            _correctionsLogic = new CorrectionsLogic(_dictionaryLogic, _formatStrings);

            string testString = _correctionsLogic.Correct(word);

            Assert.That(testString,Is.EqualTo("{"+word+"?}"));
        }

        [Test]
        [TestCase("spaitrn")]
        [TestCase("erplaint")]
        [TestCase("paintwe")]
        public void DeletesDoubleWordNotFound(string word)
        {
            List<string> inputDictionary = new List<string>() { "spain", "plaint", "paint" };
            _dictionaryLogic = new DictionaryLogic(inputDictionary, _alphabetUS);
            _correctionsLogic = new CorrectionsLogic(_dictionaryLogic, _formatStrings);

            string testString = _correctionsLogic.Correct(word);

            Assert.That(testString, Is.EqualTo("{" + word + "?}"));
        }
        public static  void Main() { }
    }
}
