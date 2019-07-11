using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace AcceptanceTestingSSAU.Pages
{
    class SsauGroupTimetablePage:Page
    {
        public IWebElement TablePanElement => FindElementByXPath("//*[@id=\"content1\"]");
        public IWebElement TablePanel => FindElementByXPath("//*[@id=\"myTabContent\"]");

        public SsauGroupTimetablePage(IWebDriver driver, double timeOut = 10) : base(driver, timeOut)
        {
        }

    }
}
