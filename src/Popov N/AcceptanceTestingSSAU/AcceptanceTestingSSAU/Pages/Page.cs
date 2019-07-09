using System;
using OpenQA.Selenium;

namespace AcceptanceTestingSSAU.Pages
{
    class Page
    {
        private IWebDriver driver;

        public Page(IWebDriver driver, double timeOut = 10.0)
        {
            this.driver = driver;
           // this.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeOut);
           // this.driver.Manage().Window.Maximize();
        }

        public IWebElement FindElementByXPath(string css)
        {
            //IWebElement el;

           // return el;
        }

        public void OpenPage(string pagePath)
        {
            //driver.Navigate().GoToUrl(pagePath);
        }

    }
}
