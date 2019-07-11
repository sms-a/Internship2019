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
        [TestCase("href", @"https://ssau.ru/student/")]
        public void SsauStartPageShouldOpen(string attribute, string valueOfAttribute)
        {
            using (_driver)
            {
                var startPage = new SsauStartPage(_driver);

                var element = startPage.ToStudent;

                Assert.That(element.GetAttribute(attribute), Is.EqualTo(valueOfAttribute));
            }
        }

        [Test]
        public void SsauSelectTimetablePageShouldOpen()
        {
            using (_driver)
            {
                var startPage = new SsauStartPage(_driver);
                var toStudentPage = startPage.OpenSelectTimetablePage();

                var classAttribute = toStudentPage.SearchGroupElement.GetAttribute("class");

                Assert.That(classAttribute, Is.EqualTo("select2-selection__placeholder"));
            }
        }

        [Test]
        [TestCase("6213-020302D")]
        public void SsauGroupTimetablePageShouldOpen(string groupNumber)
        {
            using (_driver)
            {
                var startPage = new SsauStartPage(_driver);
                var selectTimeTablePage = startPage.OpenSelectTimetablePage();

                //var groupTimetablePage = selectTimeTablePage.OpenSelectedGroup(groupNumber);

                /* Это альтернатива верхней закоментированной строке.
                 Причина: невозможность перейти на страницу группы закоментированным путем. 
                 События нажатия Enter и клика мышью по форме не обрабатываются сайтом*/
                var groupTimetablePage = new SsauGroupTimetablePage(_driver);
                selectTimeTablePage.OpenPage("https://ssau.ru/rasp?group="+ groupNumber);
                /* */

                var tableElement = groupTimetablePage.TablePanel.FindElement(By.XPath("*[@id=\"content1\"]"));

                Assert.That(tableElement, Is.EqualTo(groupTimetablePage.TablePanElement));
            }
        }

    }
}
