using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace SsauRuTest
{
    class HomePage : BasePage
    {
        private readonly string url = "https://ssau.ru/";
        private readonly string studentLinkElementSelector = "header > div.content-main > section > div.header-top > div.top-menu > ul > li:nth-child(2) > a";
        private readonly string timetableSelector = "header > div.content-main > section > div.header-top > div.top-menu > ul > li:nth-child(2) > div > div:nth-child(1) > p:nth-child(1) > a";

        /// <summary>
        /// Открытие начальной страницы Самарского университета с помощью произвольного веб-драйвера.
        /// </summary>
        /// <param name="webDriver">Веб-драйвер для открытия страницы Самарского университета</param>
        /// <param name="maximize">Настройка развертывания окна браузера на весь экран</param> 
        public HomePage(IWebDriver webDriver, bool maximize): base(webDriver, maximize)
        {
            OpenPage(url);
        }
        /// <summary>
        /// Получение HTML-элемента со ссылкой на меню "Студенту".
        /// </summary>
        /// <returns>HTML-элемент со ссылкой на меню "Студенту" (IWebElement)</returns>
        public IWebElement GetStudentMenuElement()
        {
            return FindElementByCss(studentLinkElementSelector);
        }
        /// <summary>
        /// Получение HTML-элемента со ссылкой на страницу расписания.
        /// </summary>
        /// <returns>HTML-элемент со ссылкой на страницу расписания (IWebElement)</returns>
        public IWebElement GetTimetableLinkElement()
        {
            return FindElementByCss(timetableSelector);
        }
    }
}
