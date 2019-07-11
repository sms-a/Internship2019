using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace AcceptanceTestingSSAU.Pages
{
    class SsauStartPage : Page
    {
        private const string ssauAddress = @"http://ssau.ru/";

        public IWebElement ToStudent => FindElementByXPath("/html/body/header/div[2]/section/div[2]/div[1]/ul/li[2]/a");
        public IWebElement ToTimetable => FindElementByXPath("/html/body/header/div[2]/section/div[2]/div[1]/ul/li[2]/div/div[1]/p[1]/a");

        public SsauStartPage(IWebDriver driver, double timeOut = 10) : base(driver, timeOut)
        {
            OpenPage(ssauAddress);
        }

        // Данный метод работает не во всех браузерах. Причина: проблемы с отображением.
        public SsauToStudentPage OpenToStudentPage()
        {
            ToStudent.Click();

            return new SsauToStudentPage(Driver);
        }

        public SsauSelectTimetablePage OpenSelectTimetablePage()
        {
            ToStudent.Click();
            ToTimetable.Click();
            return new SsauSelectTimetablePage(Driver);
        }
    }
}
