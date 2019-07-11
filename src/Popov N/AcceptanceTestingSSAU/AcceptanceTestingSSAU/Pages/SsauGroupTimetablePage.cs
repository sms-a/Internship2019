using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace AcceptanceTestingSSAU.Pages
{
    class SsauGroupTimetablePage:Page
    {
        public IWebElement TablePanElement => FindElementByCss("#content1");

        public SsauGroupTimetablePage(IWebDriver driver, double timeOut = 10) : base(driver, timeOut)
        {
        }

        

    }
}
