using System.Collections.Generic;
using MySpellChecker;
using MySpellChecker.Interfaces;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class IOTests
    {
        private IInputOutput _ioStrings;

        [SetUp]
        public void Init()
        {
            _ioStrings = new IOStrings();
        }

        [Test]
        public void WriteNullString()
        {
            Assert.That(() =>_ioStrings.WriteLine(null),Throws.ArgumentNullException);
        }
    }
}
