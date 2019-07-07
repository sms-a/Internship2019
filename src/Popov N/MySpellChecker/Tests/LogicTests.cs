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
        private string _alphabetUS = "abcdefghijklmnopqrstuvwxyz";

        [SetUp]
        public void Init()
        {
            _formatStrings = new FormatStrings();
        }

        [Test]
        [TestCase("plain")]
        [TestCase("spain")]
        [TestCase("rain")]
        [TestCase("plaint")]
        public void ContainsWordToDictionary(string inputWord)
        {
            List<string> inputDictionary = new List<string>() { "rain", "spain", "plain" , "plaint"};
            DictionaryLogic dictionaryLogic = new DictionaryLogic(inputDictionary,_alphabetUS);

            bool isContains = dictionaryLogic.Contains(inputWord);

            Assert.That(isContains,Is.EqualTo(true));
        }

        [Test]
        [TestCase("in")]
        [TestCase("stpain")]
        public void NotContainsWordToDictionary(string inputWord)
        {
            List<string> inputDictionary = new List<string>() { "rain", "spain", "plain", "plaint" };
            DictionaryLogic dictionaryLogic = new DictionaryLogic(inputDictionary,_alphabetUS);

            bool isContains = dictionaryLogic.Contains(inputWord);

            Assert.That(isContains, Is.EqualTo(false));
        }

        [Test]
        public void OutputTrueString()
        {
            List<string> inputDictionary = new List<string>(){ "rain", "spain", "plain", "plaint", "pain", "main", "mainly", "the", "in", "on", "fall", "falls", "his", "was"};
            List<string> wordsArrayList = new List<string>() { "hte", "rame", "in", "pain", "fells", "mainy", "oon", "teh", "lain", "was", "hints", "pliant" };
            DictionaryLogic dictionaryLogic = new DictionaryLogic(inputDictionary, _alphabetUS);
            CorrectionsLogic correctionsLogic = new CorrectionsLogic(dictionaryLogic,_formatStrings);

            string output = "";
            foreach (string s in wordsArrayList)
            {
                output += correctionsLogic.Correct(s)+" ";
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
            DictionaryLogic dictionaryLogic = new DictionaryLogic(inputDictionary, _alphabetUS);
            CorrectionsLogic correctionsLogic = new CorrectionsLogic(dictionaryLogic, _formatStrings);

            string testString = correctionsLogic.Correct(wordUnknown);

            Assert.AreEqual("{"+wordUnknown+"?}", testString);
        }

        [Test]
        public void ReturnAnSomeWords()
        {
            List<string> inputDictionary = new List<string>() {  "spain", "plaint", "paint"};
            string word = "ptain";
            DictionaryLogic dictionaryLogic = new DictionaryLogic(inputDictionary, _alphabetUS);
            CorrectionsLogic correctionsLogic = new CorrectionsLogic(dictionaryLogic, _formatStrings);

            string testString = correctionsLogic.Correct(word);

            Assert.AreEqual("{spain paint}", testString);
        }

        [Test]
        [TestCase("spn")]
        [TestCase("pnt")]
        [TestCase("int")]
        public void InsertsDoubleWordNotFound(string word)
        {
            List<string> inputDictionary = new List<string>() { "spain", "plaint", "paint" };
            DictionaryLogic dictionaryLogic = new DictionaryLogic(inputDictionary, _alphabetUS);
            CorrectionsLogic correctionsLogic = new CorrectionsLogic(dictionaryLogic, _formatStrings);

            string testString = correctionsLogic.Correct(word);

            Assert.That(testString,Is.EqualTo("{"+word+"?}"));
        }

        [Test]
        [TestCase("spaitrn")]
        [TestCase("erplaint")]
        [TestCase("paintwe")]
        public void DeletesDoubleWordNotFound(string word)
        {
            List<string> inputDictionary = new List<string>() { "spain", "plaint", "paint" };
            DictionaryLogic dictionaryLogic = new DictionaryLogic(inputDictionary, _alphabetUS);
            CorrectionsLogic correctionsLogic = new CorrectionsLogic(dictionaryLogic, _formatStrings);

            string testString = correctionsLogic.Correct(word);

            Assert.That(testString, Is.EqualTo("{" + word + "?}"));
        }
        public static  void Main() { }
    }
}
