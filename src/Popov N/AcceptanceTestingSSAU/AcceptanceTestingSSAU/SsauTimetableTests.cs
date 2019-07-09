using System;
using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using  AcceptanceTestingSSAU.Pages;

namespace AcceptanceTestingSSAU
{
    [TestFixture]
    class SsauTimetableTests
    {
        [Test]
        public void SsauStartPageShouldOpen()
        {
            using (var driver = new FirefoxDriver(AppDomain.CurrentDomain.BaseDirectory))
            {
                var startPage = new SsauStartPage(driver);

                var element = startPage.TimetableOfClasses;

                Assert.That(element.GetAttribute("href"), Is.EqualTo("/rasp/"));
            }


        }


    }
}
