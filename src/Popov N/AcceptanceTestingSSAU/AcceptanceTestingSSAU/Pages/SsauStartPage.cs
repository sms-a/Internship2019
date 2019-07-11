using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace AcceptanceTestingSSAU.Pages
{
    class SsauStartPage : Page
    {

        public IWebElement ToStudent => FindElementByXPath("/html/body/header/div[2]/section/div[2]/div[1]/ul/li[2]/a");

        public SsauStartPage(IWebDriver driver, double timeOut = 10) : base(driver, timeOut)
        {
            OpenPage(@"http://ssau.ru/");
        }

        public SsauToStudentPage OpenToStudentPage()
        {
            ToStudent.Click();

            return new SsauToStudentPage(Driver);
        }

    }
}
