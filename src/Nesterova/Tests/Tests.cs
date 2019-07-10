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
            //arrange
            var checkingWord = "sadness";
            var dictionary = new List<string>();
            dictionary.Add(checkingWord);
            //act
            var checker = new BuisnessLogic.Checker(dictionary);
            var actualResult= checker.GetCorrectWord(checkingWord);
            //assert
            Assert.Equal(checkingWord, actualResult);
        }
        [Fact]
        public void WordIsNotCorrect()
        {
            //arrange
            var checkingWord = "sad";
            var dictionary = new List<string>() {"sadness"};
            var expectedResult = "{" + checkingWord + "?}";
            //act
            var checker = new BuisnessLogic.Checker(dictionary);
            var actualResult = checker.GetCorrectWord(checkingWord);
            //assert
            Assert.Equal(expectedResult, actualResult);
        }
        [Fact]
        public void WordHaveOneCorrectVariatWithOneEdit()
        {
            //arrange
            var checkingWord = "sdness";
            var dictionary = new List<string>(){ "sadness", "july", "empty", "a", "awful" };
            var expectedResult = "sadness";
            //act
            var checker = new BuisnessLogic.Checker(dictionary);
            var actualResult = checker.GetCorrectWord(checkingWord);
            //assert
            Assert.Equal(expectedResult, actualResult);
        }
        [Fact]
        public void WordHaveFewCorrectVariatsWithOneEdit()
        {
            //arrange
            var checkingWord = "sdness";
            var dictionary = new List<string>() { "sadness", "sness", "sodness", "a", "awful" };
            var expectedResult = "{sadness sness sodness}";
            //act
            var checker = new BuisnessLogic.Checker(dictionary);
            var actualResult = checker.GetCorrectWord(checkingWord);
            //assert
            Assert.Equal(expectedResult, actualResult);
        }
        [Fact]
        public void WordHaveOneCorrectVariantWhithTwoEdits()
        {
            //arrange
            var checkingWord = "sness";
            var dictionary = new List<string>() { "sadness", "july", "empty", "a", "awful" };
            var expectedResult = "sadness";
            //act
            var checker = new BuisnessLogic.Checker(dictionary);
            var actualResult = checker.GetCorrectWord(checkingWord);
            //assert
            Assert.Equal(expectedResult, actualResult);
        }
        [Fact]
        public void WordHaveCorrectVariantWithOneOrTwoEdits()
        {
            //arrange
            var checkingWord = "sdness";
            var dictionary = new List<string>() { "sadness", "sjness", "empty", "a", "awful" };
            var expectedResult = "sadness";
            //act
            var checker = new BuisnessLogic.Checker(dictionary);
            var actualResult = checker.GetCorrectWord(checkingWord);
            //assert
            Assert.Equal(expectedResult, actualResult);
        }
        [Fact]
        public void WordHaveFewCorrectVariantsWhithTwoEdits()
        {
            //arrange
            var checkingWord = "sness";
            var dictionary = new List<string>() { "sadness", "sjaness", "empty", "a", "awful" };
            var expectedResult = "{sadness sjaness}";
            //act
            var checker = new BuisnessLogic.Checker(dictionary);
            var actualResult = checker.GetCorrectWord(checkingWord);
            //assert
            Assert.Equal(expectedResult, actualResult);
        }
        [Fact]
        public void ChechingWordIsSoLong()
        {
            //arrange
            var checkingWord = "asfmjshguwehioqwufuwgvuwreufhwedjhgaygdjahbfuagufgqwfvyuqfvyqwfgyqw";
            var dictionary = new List<string>();
            //act
            var checker = new BuisnessLogic.Checker(dictionary);
            var actualResult = checker.GetCorrectWord(checkingWord);
            //assert
            Assert.Equal(checkingWord, actualResult);
        }
        [Fact]
        public void InputIsCaseinsensitive()
        {
            //arrange
            var checkingWord = "MAiN";
            var dictionary = new List<string>() {"main"};
            var expectedResult = "{MAiN?}";
            //act
            var checker = new BuisnessLogic.Checker(dictionary);
            var actualResult = checker.GetCorrectWord(checkingWord);
            //assert
            Assert.Equal(expectedResult, actualResult);
        }
    }
}
