using System;
using System.Collections.Generic;
using Xunit;

namespace Tests
{
    public class Tests
    {
        [Fact]
        public void WordIsCorrect()
        {
            string word = "sadness";
            List<string> dictionary = new List<string>();
            dictionary.Add(word);
            var checker = new SpellChecker.Checker(dictionary);
            Assert.Equal(word, checker.GetCorrectWord(word));
        }
        [Fact]
        public void WordIsNotCorrect()
        {
            string word = "sad";
            List<string> dictionary = new List<string>() {"sadness"};
            var checker = new SpellChecker.Checker(dictionary);
            string result = "{" + word + "?}";
            Assert.Equal(result, checker.GetCorrectWord(word));
        }
        [Fact]
        public void WordHaveOneCorrectVariatWithOneEdit()
        {
            string word = "sdness";
            List<string> dictionary = new List<string>(){ "sadness", "july", "empty", "a", "awful" };
            var checker = new SpellChecker.Checker(dictionary);
            Assert.Equal("sadness", checker.GetCorrectWord(word));
        }
        [Fact]
        public void WordHaveFewCorrectVariatsWithOneEdit()
        {
            string word = "sdness";
            List<string> dictionary = new List<string>() { "sadness", "sness", "sodness", "a", "awful" };
            var checker = new SpellChecker.Checker(dictionary);
            Assert.Equal("{sadness sness sodness}", checker.GetCorrectWord(word));
        }
        [Fact]
        public void WordHaveOneCorrectVariantWhithTwoEdits()
        {
            string word = "sness";
            List<string> dictionary = new List<string>() { "sadness", "july", "empty", "a", "awful" };
            var checker = new SpellChecker.Checker(dictionary);
            Assert.Equal("sadness", checker.GetCorrectWord(word));
        }
        [Fact]
        public void WordHaveCorrectVariantWithOneOrTwoEdits()
        {
            string word = "sdness";
            List<string> dictionary = new List<string>() { "sadness", "sjness", "empty", "a", "awful" };
            var checker = new SpellChecker.Checker(dictionary);
            Assert.Equal("sadness", checker.GetCorrectWord(word));
        }
        [Fact]
        public void WordHaveFewCorrectVariantsWhithTwoEdits()
        {
            string word = "sness";
            List<string> dictionary = new List<string>() { "sadness", "sjaness", "empty", "a", "awful" };
            var checker = new SpellChecker.Checker(dictionary);
            Assert.Equal("{sadness sjaness}", checker.GetCorrectWord(word));
        }
        [Fact]
        public void ChechingWordIsSoLong()
        {
            string word = "asfmjshguwehioqwufuwgvuwreufhwedjhgaygdjahbfuagufgqwfvyuqfvyqwfgyqw";
            List<string> dictionary = new List<string>();
            var checker = new SpellChecker.Checker(dictionary);
            Assert.Equal(word, checker.GetCorrectWord(word));
        }
        [Fact]
        public void InputIsCaseinsensitive()
        {
            string word = "MAiN";
            List<string> dictionary = new List<string>() {"main"};
            var checker = new SpellChecker.Checker(dictionary);
            Assert.Equal("{MAiN?}", checker.GetCorrectWord(word));
        }
    }
}
