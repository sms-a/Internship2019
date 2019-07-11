using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SsauScheduleTest
{
    public class BasePage
    {
        protected IWebDriver Driver { get; private set; }
        public BasePage(IWebDriver driver, double timeout=10.0)
        {
            Driver = driver;
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeout);
            Driver.Manage().Window.Maximize();
        }
        public IWebElement FindElementByCss(string css)
        {
            IWebElement element;
            try
            {
                element = Driver.FindElement(By.CssSelector(css));
            }
            catch (NoSuchElementException ex)
            {
                throw new NoSuchElementException(
                    string.Format("CSS selector = \"{0}\"\n", css),
                    ex);
            }
            return element;
        }
        public void OpenPage(string pagePath)
        {
            Driver.Navigate().GoToUrl(pagePath);
        }
    }
}
