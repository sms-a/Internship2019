using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace AcceptanceTestingSSAU.Pages
{
    class SsauSelectTimetablePage:Page
    {
        public IWebElement SearchGroupElement => FindElementByXPath(@"//*[@id=""select2-timetableSelect-container""]/span");
        private IWebElement InputSearchGroupElement => FindElementByCss(@"input.select2-search__field");

        private IWebElement SearchResultElement =>
            FindElementByXPath("//*[@id=\"select2-timetableSelect-results\"]/li[1]");

        public SsauSelectTimetablePage(IWebDriver driver, double timeOut = 10) : base(driver, timeOut)
        {
        }

        public SsauGroupTimetablePage OpenSelectedGroup(string selectedGroup)
        {
            SearchGroupElement.Click();

            InputSearchGroupElement.SendKeys(selectedGroup);
            InputSearchGroupElement.Click();
            InputSearchGroupElement.SendKeys(Keys.Enter);

            //Нажатие на предложенный элемент не дает никакого результата
            //SearchResultElement.Click();

            return new SsauGroupTimetablePage(Driver);
        }

    }
}
