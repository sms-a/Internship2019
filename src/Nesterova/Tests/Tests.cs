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
    }
}
