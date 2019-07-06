using System;
using System.Collections;
using System.Collections.Generic;
using MySpellChecker;
using MySpellChecker.Interfaces;
using NUnit.Framework;

namespace Tests
{
    class LogicTests
    {
        private string _alphabetUS = "abcdefghijklmnopqrstuvwxyz";

        [Test]
        public void ContainsWordToDictionary()
        {
            List<string> inputDictionary = new List<string>() { "rain", "spain", "plain" , "plaint"};
            string inputWord = "plain";
            DictionaryLogic dictionaryLogic = new DictionaryLogic(inputDictionary);

            bool isContains = dictionaryLogic.Contains(inputWord);

            Assert.AreEqual(true, isContains);
        }

        [Test]
        public void NotContainsWordToDictionary()
        {
            List<string> inputDictionary = new List<string>() { "rain", "spain", "plain", "plaint" };
            string inputWord = "in";
            DictionaryLogic dictionaryLogic = new DictionaryLogic(inputDictionary);

            bool isContains = dictionaryLogic.Contains(inputWord);

            Assert.AreEqual(false, isContains);
        }

        [Test]
        public void OutputTrueString()
        {
            List<string> inputDictionary = new List<string>(){ "rain", "spain", "plain", "plaint", "pain", "main", "mainly", "the", "in", "on", "fall", "falls", "his", "was"};
            List<string> wordsArrayList = new List<string>() { "hte", "rame", "in", "pain", "fells", "mainy", "oon", "teh", "lain", "was", "hints", "pliant" };
            DictionaryLogic dictionaryLogic = new DictionaryLogic(inputDictionary);
            IFormatStrings formatStrings = new FormatStrings();
            CorrectionsLogic correctionsLogic = new CorrectionsLogic(dictionaryLogic,formatStrings, _alphabetUS);

            string output = "";
            foreach (string s in wordsArrayList)
            {
                output += correctionsLogic.Correct(s)+" ";
            }
            
            Assert.AreEqual("the {rame?} in pain falls {main mainly} on the plain was {hints?}", output.Trim(' '));

        }

        [Test]
        public void ReturnAnUnknownWord()
        {
            List<string> inputDictionary = new List<string>() { "rain", "spain", "plain", "plaint", "pain", "main", "mainly", "the", "in", "on", "fall", "falls", "his", "was" };
            string wordUnknown = "srame";
            DictionaryLogic dictionaryLogic = new DictionaryLogic(inputDictionary);
            IFormatStrings formatStrings = new FormatStrings();
            CorrectionsLogic correctionsLogic = new CorrectionsLogic(dictionaryLogic, formatStrings, _alphabetUS);

            string testString = correctionsLogic.Correct(wordUnknown);

            Assert.AreEqual("{"+wordUnknown+"?}", testString);
        }

        [Test]
        public void ReturnAnSomeWords()
        {
            List<string> inputDictionary = new List<string>() {  "spain", "plaint", "paint"};
            string word = "ptain";
            DictionaryLogic dictionaryLogic = new DictionaryLogic(inputDictionary);
            IFormatStrings formatStrings = new FormatStrings();
            CorrectionsLogic correctionsLogic = new CorrectionsLogic(dictionaryLogic, formatStrings, _alphabetUS);

            string testString = correctionsLogic.Correct(word);

            Assert.AreEqual("{spain paint}", testString);
        }


        public static  void Main() { }
    }
}
