using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SsauScheduleTest
{
    public class SsauStartPage : BasePage
    {
        /// <summary>
        /// Кнопка "Студенту" в верхнем меню главной страницы сайта
        /// </summary>
        public IWebElement StudentButton
        {
            get
            {
                return FindElementByCss("body > header > div.content-main > section > div.header-top > div.top-menu > ul > li:nth-child(2) > a");
            }
        }
        /// <summary>
        /// Кнопка "Расписание" в выпадающем меню "Студент"
        /// </summary>
        public IWebElement ScheduleButton
        {
            get
            {
                return FindElementByCss("body > header > div.content-main > section > div.header-top > div.top-menu > ul > li:nth-child(2) > div > div:nth-child(1) > p:nth-child(1) > a");
            }
        }
        public SsauStartPage(IWebDriver driver): base(driver)
        {
            OpenPage("http://ssau.ru");
        }
        /// <summary>
        /// Переходис с главной страницы сайта на страницу поиска расписания
        /// </summary>
        public SsauSearchSchedulePage GoToScheduleSearchPage()
        {
            var studentMenuButton = StudentButton;
            studentMenuButton.Click();
            var goToScheduleButton = ScheduleButton;
            goToScheduleButton.Click();
            return new SsauSearchSchedulePage(Driver);
        }

    }
}
