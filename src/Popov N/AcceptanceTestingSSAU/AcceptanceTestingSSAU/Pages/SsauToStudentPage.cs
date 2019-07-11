using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace AcceptanceTestingSSAU.Pages
{
    class SsauToStudentPage:Page
    {
        public IWebElement Timetable => FindElementByCss("body > div.container > div.body1-text > ul > li:nth - child(1) > a");

        public SsauToStudentPage(IWebDriver driver, double timeOut = 10) : base(driver, timeOut)
        {
            
        }

        public SsauSelectTimetablePage OpenTimetable()
        {
            Timetable.Click();

            return  new SsauSelectTimetablePage(Driver);
        }

    }
}
