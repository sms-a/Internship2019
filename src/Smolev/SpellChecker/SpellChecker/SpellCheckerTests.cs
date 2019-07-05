using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellChecker
{
    public class SpellCheckerTests
    {


        [Test]
        public void WordIsCorrectIfInDictionaryIgnoreCase()
        {
            Assert.That(SpellChecker.CheckWord("АБВГдеж", new string[] { "абвж", "абвгдеж" }), Is.EqualTo("АБВГдеж"));
        }

        [Test]
        public void WordIsCorrectIfInDictionary()
        {
            Assert.That(SpellChecker.CanReplace("абвгдеж", "абвгдеж"), Is.EqualTo(0));
        }

        [TestCase("adef", "asdef", ExpectedResult = 1)]
        [TestCase("adef", "asdsef", ExpectedResult = 2)]
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
        [TestCase("компддтер", "компьютер", ExpectedResult = -1)]
        [TestCase("я", "а", ExpectedResult = 2)]
        public int DetectOneIncorrectLetter(string checkword, string dictword)
        {
            return SpellChecker.CanReplace(checkword, dictword);
        }


    }
}
