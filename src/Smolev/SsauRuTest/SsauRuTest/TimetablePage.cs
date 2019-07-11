using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SsauRuTest
{
    class TimetablePage : BasePage
    {
        private readonly string inputElementSelector = "body > div:nth-child(5) > div:nth-child(3) > div > div:nth-child(2) > span > span.selection > span";
        private readonly string enterGroupNumElementSelector = "body > span > span > span.select2-search.select2-search--dropdown > input";
        private readonly string dropdownMenuSelectGroupElementSelector = "#select2-timetableSelect-results > li";
        private readonly string timetableElementId = "myTabContent";
        private readonly int timeout = 10;

        /// <summary>
        /// Открытие страницы расписаний групп с помощью произвольного веб-драйвера.
        /// </summary>
        /// <param name="webDriver">Веб-драйвер для открытия страницы расписаний групп</param>
        /// <param name="maximize">Настройка развертывания окна браузера на весь экран</param> 
        public TimetablePage(IWebDriver webDriver, bool maximize):base(webDriver, maximize)
        {
            var ssauHomePage = new HomePage(webDriver, maximize);
            ssauHomePage.GetStudentMenuElement().Click();
            ssauHomePage.GetTimetableLinkElement().Click();
        }

        /// <summary>
        /// Для заданной группы проверяет, имеется ли ее расписание на сайте университета.
        /// </summary>
        /// <param name="group">Номер группы</param>
        /// <returns>Имеется ли расписание на сайте университета (bool)</returns>
        public bool FindGroupTimetableInGroupsListMenu(string group)
        {
            // короче четырех цифр групп точно нет. Если это не проверять, может возникнуть ситуация, когда мы при вводе
            // трех цифр получаем расписание такой группы с номером из четырех цифр,
            // у которой уникальны первые три цифры ("631" => 6310)
            if (group.Length<4)
            {
                return false;
            }
            // зато есть такие группы, у которых номер совпадает, а код специальности - нет (такие есть на 4 факультете)

            // вводим номер группы в поле "Поиск группы"
            FindElementByCss(inputElementSelector).Click();
            var enterGroupNumElement = FindElementByCss(enterGroupNumElementSelector);
            enterGroupNumElement.SendKeys(group.ToString());
            IWait <IWebDriver> wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(timeout));
            // ждем, пока сайт не обновит список и когда появится пункт с группой (иначе драйвер щелкнет по строке "Поиск..." и ничего не произойдет)
            wait.Until(webDriver => !FindElementByCss(dropdownMenuSelectGroupElementSelector).Text.StartsWith("Поиск"));
            var dropdownMenuSelectGroupElements = webDriver.FindElements(By.CssSelector(dropdownMenuSelectGroupElementSelector));
            // проверка, что у нас группа есть и она только одна (т.е. мы можем ее точно определить)
            if (dropdownMenuSelectGroupElements.Count == 1 && dropdownMenuSelectGroupElements[0].Text.StartsWith(group))
            {
                FindElementByCss(dropdownMenuSelectGroupElementSelector).Click();
                return DoesTimetableCurrentlyExistForThisGroup();
            }
            //иначе такой группы точно нет; если значение больше 1, то точно какую группу мы имели в виду определить нельзя
            else
            {
                return false;
            }

        }

        /// <summary>
        /// Проверяет, есть ли для выбранной из выпадающего меню группы расписание.
        /// </summary>
        /// <returns>Имеется ли расписание на сайте университета (bool)</returns>
        /// Примечание: если группа выпадает в меню только когда для нее на сайте есть расписание, этот метод можно не использовать 
        public bool DoesTimetableCurrentlyExistForThisGroup()
        {
            try
            {
                webDriver.FindElement(By.Id(timetableElementId));
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

    }
}
