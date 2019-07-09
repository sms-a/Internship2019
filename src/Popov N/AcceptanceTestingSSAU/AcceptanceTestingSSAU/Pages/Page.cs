using System;
using OpenQA.Selenium;

namespace AcceptanceTestingSSAU.Pages
{
    abstract class Page
    {
        protected IWebDriver Driver { get; private set; }

        public Page(IWebDriver driver, double timeOut = 10.0)
        {
            Driver = driver;
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeOut);
            Driver.Manage().Window.Maximize();
        }

        public IWebElement FindElementByXPath(string xPath)
        {
            IWebElement el;
            try
            {
                el = Driver.FindElement(By.XPath(xPath));
            }
            catch (NoSuchElementException ex)
            {
                throw new NoSuchElementException(
                    $"XPath selector = \"{xPath}\"\n",
                    ex);
            }

            return el;
        }

        public IWebElement FindElementByCss(string css)
        {
            IWebElement el;
            try
            {
                el = Driver.FindElement(By.CssSelector(css));
            }
            catch (NoSuchElementException ex)
            {
                throw new NoSuchElementException(
                    $"CSS selector = \"{css}\"\n",
                    ex);
            }

            return el;
        }

        public void OpenPage(string pagePath)
        {
            Driver.Navigate().GoToUrl(pagePath);
        }

    }
}
