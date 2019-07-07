using System.Collections.Generic;
using System.Linq;
using MySpellChecker;
using MySpellChecker.Interfaces;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class FormatStringsTests
    {
        private IFormatStrings _formatStrings;

        [SetUp]
        public void Init()
        {
            _formatStrings = new FormatStrings();
        }

        [Test]
        [TestCase("")]
        [TestCase("rrrr")]
        public void ReturnUnknownString(string str)
        {
            Assert.AreEqual(_formatStrings.FormatStringToUnknown(str), "{"+str +"?}");
        }

        [Test]
        [TestCase("", "","r")]
        [TestCase("fsd", "w3","r3")]
        public void ReturnFamousStringWithSomeWord(params string[] w)
        {
            IEnumerable<string> words = from s in w select s;
            string trueResult = "";
            for (var i = 0; i < w.Length; i++)
            {
                if(i == w.Length-1) {trueResult += w[i]; continue;}
                trueResult += w[i] + " ";
            }

            Assert.That(_formatStrings.FormatStringsToFamous(words), Is.EqualTo("{"+trueResult+"}"));
        }

        [Test]
        [TestCase("rrrr")]
        [TestCase("")]
        public void ReturnFamousStringWithSingleWord(string word)
        {
            Assert.That(_formatStrings.FormatStringsToFamous(new[]{word}), Is.EqualTo(word));
        }
    }
}

