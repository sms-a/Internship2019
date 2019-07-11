using System;
using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using  AcceptanceTestingSSAU.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AcceptanceTestingSSAU
{
    [TestFixture]
    class SsauTimetableTests
    {
        private IWebDriver _driver;

        [SetUp]
        public void InitDriver()
        {
            _driver = new ChromeDriver(AppDomain.CurrentDomain.BaseDirectory);
        }


        [Test]
        public void SsauStartPageShouldOpen()
        {
            using (_driver)
            {
                var startPage = new SsauStartPage(_driver);

                var element = startPage.ToStudent;

                Assert.That(element.GetAttribute("href"), Is.EqualTo(@"/student/"));
            }
        }

        [Test]
        public void SsauToStudentPageShouldOpen()
        {
            using (_driver)
            {
                var startPage = new SsauStartPage(_driver);
                var toStudentPage = startPage.OpenToStudentPage();

                var element = toStudentPage.Timetable;

                Assert.That(element.GetAttribute("href"), Is.EqualTo("/rasp/"));
            }
        }

        [Test]
        public void SsauSelectTimetablePageShouldOpen()
        {
            string groupNumber = "6213-020302D";

            using (_driver)
            {
                var startPage = new SsauStartPage(_driver);
                var toStudentPage = startPage.OpenToStudentPage();
                var selectTimeTablePage = toStudentPage.OpenTimetable();

                var groupTimetablePage = selectTimeTablePage.OpenSelectedGroup(groupNumber);
                var element = groupTimetablePage.TablePanElement.FindElement(By.CssSelector("body"));

                Assert.That(element, Is.TypeOf<IWebElement>());
            }
        }

    }
}
