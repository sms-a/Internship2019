using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace AcceptanceTestingSSAU.Pages
{
    class SsauStartPage : Page
    {

        public IWebElement TimetableOfClasses => FindElementByCss("body > header > div.content-main > section > div.header-top > div.top-menu > ul > li:nth-child(2) > div > div:nth-child(1) > p:nth-child(1) > a");

        public SsauStartPage(IWebDriver driver, double timeOut = 10) : base(driver, timeOut)
        {
            OpenPage(@"http://ssau.ru/");
        }

    }
}
