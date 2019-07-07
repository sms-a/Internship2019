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
            List<string> dictionary = new List<string>();
            dictionary.Add("sadness");
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
        public void WordHaveFewCorrectVariatWithOneEdit()
        {
            string word = "sdness";
            List<string> dictionary = new List<string>() { "sadness", "sness", "sodness", "a", "awful" };
            var checker = new SpellChecker.Checker(dictionary);
            Assert.Equal("{ sadness sness sodness }", checker.GetCorrectWord(word));
        }

    }
}
