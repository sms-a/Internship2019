using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace SsauScheduleTest
{
    public class SsauSearchSchedulePage:BasePage
    {
        /// <summary>
        /// Поле поиска расписания по номеру группы
        /// </summary>
        public IWebElement SearchSpan
        {
            get
            {
                return FindElementByCss("body > div:nth-child(5) > div:nth-child(3) > div > div:nth-child(2) > span > span.selection > span");
            }
        }
        /// <summary>
        /// Поле ввода номера группы для поиска
        /// </summary>
        public IWebElement SearchInput
        {
            get
            {
                return FindElementByCss("body > span > span > span.select2-search.select2-search--dropdown > input");
            }
        }
        /// <summary>
        /// Первый результат поиска. Если поиск не завершен, содержит текст "Поиск...", если поиск не дал результатов - 
        /// текст "Ничего не найдено"
        /// </summary>
        public IWebElement FirstResult
        {
            get
            {
                return FindElementByCss("#select2-timetableSelect-results > li");
            }
        }
        public SsauSearchSchedulePage(IWebDriver driver) : base(driver)
        {
        }
        /// <summary>
        /// Вводим номер группы и ждем окончания поиска. Если расписание найдено, первая строка поиска будет содерать
        /// ссылку на расписание. В противном случае - текст "Ничего не найдено"
        /// </summary>
        /// <param name="groupNumber"></param>
        public bool CanFoundScheduleOfGroup(string groupNumber)
        {
            SearchSpan.Click();
            SearchInput.SendKeys(groupNumber);
            IWait<IWebDriver> wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10.0));
            wait.Until(webDriver => !FirstResult.Text.StartsWith("Поиск"));
            return !FirstResult.Text.StartsWith("Ничего");
        }
    }
}