using System.Collections.Generic;
using MySpellChecker;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    class DictionaryLogicTests
    {
        private string _alphabetUS = "abcdefghijklmnopqrstuvwxyz";

        [Test]
        [TestCase("plain")]
        [TestCase("spain")]
        [TestCase("rain")]
        [TestCase("plaint")]
        public void ContainsWordToDictionary(string inputWord)
        {
            List<string> inputDictionary = new List<string>() { "rain", "spain", "plain", "plaint" };
            DictionaryLogic dictionaryLogic = new DictionaryLogic(inputDictionary, _alphabetUS);

            bool isContains = dictionaryLogic.Contains(inputWord);

            Assert.That(isContains, Is.EqualTo(true));
        }

        [Test]
        [TestCase("in")]
        [TestCase("stpain")]
        public void NotContainsWordToDictionary(string inputWord)
        {
            List<string> inputDictionary = new List<string>() { "rain", "spain", "plain", "plaint" };
            DictionaryLogic dictionaryLogic = new DictionaryLogic(inputDictionary, _alphabetUS);

            bool isContains = dictionaryLogic.Contains(inputWord);

            Assert.That(isContains, Is.EqualTo(false));
        }
    }
}
