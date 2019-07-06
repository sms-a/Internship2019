using NUnit.Framework;
using System;
using System.Collections.Generic;


namespace SpellChecker
{
    public class SpellCheckerTests
    {


        [Test]
        public void WordIsCorrectIfInDictionaryIgnoreCase()
        {
            Assert.That(SpellChecker.CheckWord("абвгдеж", new string[] { "абвж", "АБВГдеж" }), Is.EqualTo("АБВГдеж"));
        }

        [Test]
        public void NoCorrections()
        {
            Assert.That(SpellChecker.CheckWord("abcdefg", new string[] { "van", "abcdr" }), Is.EqualTo("{abcdefg?}"));
        }

        [Test]
        public void OneEditCorrection()
        {
            Assert.That(SpellChecker.CheckWord("Abcde", new string[] { "van", "abcdef", "abcdf" }), Is.EqualTo("abcdef"));
        }

        [Test]
        public void MoreThanOneEditCorrection()
        {
            Assert.That(SpellChecker.CheckWord("Three", new string[] { "van", "Tree", "Threek", "Threk", "sthree" }), Is.EqualTo("{Tree, Threek, sthree}"));
        }

        [Test]
        public void MoreThanOneCorrectionWithEditDistTwo()
        {
            Assert.That(SpellChecker.CheckWord("Two", new string[] { "too", "tewot", "van", "three" }), Is.EqualTo("{too, tewot}"));
        }

        [Test]
        public void MoreThanOneCorrectionWithEditDistTwoAndChangedOrderInDict()
        {
            Assert.That(SpellChecker.CheckWord("Two", new string[] { "tewot", "van", "too",  "three" }), Is.EqualTo("{tewot, too}"));
        }

        [Test]
        public void WhiteSpaceAndOtherNonAlphabetMustBeIntact()
        {
            Assert.That(SpellChecker.CheckText("  one!\n  two-20\t'three apples , yesh'! ", new string[] {"apples", "too", "tree", "yes", "yeah" , "y"}), Is.EqualTo("  {one?}!\n  too-20\t'tree apples , {yes, yeah}'! "));
        }

        [Test]
        public void OneCorrectWordString()
        {
            Assert.That(SpellChecker.CheckText("a", new string[] { "abs", "ads", "b", "c", "a" }), Is.EqualTo("a"));
        }


        [Test]
        public void WordIsCorrectIfInDictionary()
        {
            Assert.That(SpellChecker.CanReplace("абвгдеж", "абвгдеж"), Is.EqualTo(0));
        }

        [TestCase("adef", "asdef", ExpectedResult = 1)]
        [TestCase("adef", "asdefs", ExpectedResult = 2)]
        [TestCase("adef", "assdef", ExpectedResult = -1)]
        [TestCase("adef", "adefss", ExpectedResult = -1)]
        [TestCase("adef", "ssadef", ExpectedResult = -1)]
        [TestCase("adef", "asdvebf", ExpectedResult = -1)]
        public int DetectOneOrTwoExtraLetters(string checkword, string dictword)
        {
            return SpellChecker.CanReplace(checkword, dictword);
        }

        [TestCase("компютер", "компьютер", ExpectedResult = 1)]
        [TestCase("кмпютер", "компьютер", ExpectedResult = 2)]
        [TestCase("омпютер", "компьютер", ExpectedResult = 2)]
        [TestCase("комютер", "компьютер", ExpectedResult = -1)]
        [TestCase("мпьютер", "компьютер", ExpectedResult = -1)]
        [TestCase("компьют", "компьютер", ExpectedResult = -1)]
        [TestCase("а", "ба", ExpectedResult = 1)]
        [TestCase("аб", "а", ExpectedResult = 1)]
        public int DetectOneOrTwoMissingLetters(string checkword, string dictword)
        {
            return SpellChecker.CanReplace(checkword, dictword);
        }

        [Test]
        public void DetectOneExtraAndOneMissingLetter()
        {
            Assert.That(SpellChecker.CanReplace("коммпьюте", "компьютер"), Is.EqualTo(2));
        }

        [TestCase("компдютер", "компьютер", ExpectedResult = 2)]
        [TestCase("abcde", "bbcde", ExpectedResult = 2)]
        [TestCase("abcde", "abcdf", ExpectedResult = 2)]
        [TestCase("компддтер", "компьютер", ExpectedResult = -1)]
        [TestCase("я", "а", ExpectedResult = 2)]
        public int DetectOneIncorrectLetter(string checkword, string dictword)
        {
            return SpellChecker.CanReplace(checkword, dictword);
        }


    }
}
