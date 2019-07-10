using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SsauRuTest
{
    class BasePage
    {
        protected IWebDriver webDriver { get; private set; }

        /// <summary>
        /// Инициализация заданного веб-браузера с настройкой расширения на весь экран.
        /// </summary>
        /// <param name="driver">Драйвер браузера, который будет работать со страницей</param>
        /// <param name="maximize">Настройка развертывания окна браузера на весь экран</param>
        public BasePage(IWebDriver driver, bool maximize)
        {
            webDriver = driver;
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10.0);
            if (maximize)
            {
                webDriver.Manage().Window.Maximize();
            }
        }

        /// <summary>
        /// Этот метод находит по заданному CSS-селектору первый соответствующий ему HTML-элемент.
        /// </summary>
        /// <param name="css">Строка с CSS-селектором</param>
        /// <returns>HTML-элемент, соответствующий селектору</returns>
        /// <exception cref="NoSuchElementException">Если на странице не существует элементов, соответствующего заданному селектору.</exception>
        public IWebElement FindElementByCss(string css)
        {
            IWebElement el;
            try
            {
                el = webDriver.FindElement(By.CssSelector(css));
            }
            catch (NoSuchElementException ex)
            {
                throw new NoSuchElementException(
                    string.Format("CSS selector = \"{0}\"\n", css),
                    ex);
            }

            return el;
        }

        /// <summary>
        /// Открытие страницы в веб-браузере.
        /// </summary>
        /// <param name="pagePath">URL страницы</param>
        public void OpenPage(string pagePath)
        {
            webDriver.Navigate().GoToUrl(pagePath);
        }
    }
}
