using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace SpellChecker.Tests
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
            Assert.That(SpellChecker.CheckWord("Three", new string[] { "van", "Tree", "Threek", "Threk", "sthree" }), Is.EqualTo("{Tree Threek sthree}"));
        }

        [Test]
        public void MoreThanOneCorrectionWithEditDistTwo()
        {
            Assert.That(SpellChecker.CheckWord("Two", new string[] { "too", "tewot", "van", "three" }), Is.EqualTo("{too tewot}"));
        }

        [Test]
        public void MoreThanOneCorrectionWithEditDistTwoAndChangedOrderInDict()
        {
            Assert.That(SpellChecker.CheckWord("Two", new string[] { "tewot", "van", "too", "three" }), Is.EqualTo("{tewot too}"));
        }

        [Test]
        public void WhiteSpaceAndOtherNonAlphabetMustBeIntact()
        {
            Assert.That(SpellChecker.CheckText("  one!\n  two-20\t'three apples , yesh'! ", new string[] { "apples", "too", "tree", "ys", "yeah", "y" }), Is.EqualTo("  {one?}!\n  too-20\t'tree apples , {ys yeah}'! "));
        }

        [Test]
        public void NoWhiteSpacesAtTextEnds()
        {
            Assert.That(SpellChecker.CheckText("one!\n  two-20\t'three apples , i yesh", new string[] { "apples", "too", "tree", "ys", "yeah", "y", "I" }), Is.EqualTo("{one?}!\n  too-20\t'tree apples , I {ys yeah}"));
        }

        [Test]
        public void OneCorrectWordString()
        {
            Assert.That(SpellChecker.CheckText("a", new string[] { "abs", "ads", "b", "c", "a" }), Is.EqualTo("a"));
        }

        [Test]
        public void SimpleSpellCheckTest()
        {
            Assert.That(SpellChecker.SpellCheck("rain spain===rain spain==="), Is.EqualTo("rain spain"));
        }

        [Test]
        public void TextbookExample()
        {
            Assert.That(SpellChecker.SpellCheck("rain spain plain plaint pain main mainly the in on fall falls his was ===\nhte rame in pain fells mainy oon teh lain was hints pliant ==="), Is.EqualTo("the {rame?} in pain falls {main mainly} on the plain was {hints?} plaint "));
        }

        [Test]
        public void WordIsCorrectIfInDictionary()
        {
            Assert.That(SpellChecker.CanReplace("абвгдеж", "абвгдеж"), Is.EqualTo(0));
        }

        [TestCase("asdef", "adef", ExpectedResult = 1)]
        [TestCase("asdefs", "adef", ExpectedResult = 2)]
        [TestCase("assdef", "adef", ExpectedResult = -1)]
        [TestCase("hints", "his", ExpectedResult = -1)]
        [TestCase("adefss", "adef", ExpectedResult = -1)]
        [TestCase("ssadef", "adef", ExpectedResult = -1)]
        [TestCase("asdvebf", "adef", ExpectedResult = -1)]
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
        [TestCase("his", "hints", ExpectedResult = -1)]
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
