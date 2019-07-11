using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace AcceptanceTestingSSAU.Pages
{
    class SsauSelectTimetablePage:Page
    {
        private IWebElement SearchGroupElement => FindElementByXPath(@"//*[@id=""select2 - timetableSelect - containe""]/span");
        private IWebElement InputSearchGroupElement => FindElementByXPath(@"/html/body/ input[@class=""select2-search__field""]");

        public SsauSelectTimetablePage(IWebDriver driver, double timeOut = 10) : base(driver, timeOut)
        {
        }

        public SsauGroupTimetablePage OpenSelectedGroup(string selectedGroup)
        {
            SearchGroupElement.Click();
            InputSearchGroupElement.SendKeys(selectedGroup);
            InputSearchGroupElement.SendKeys(Keys.Enter);

            return new SsauGroupTimetablePage(Driver);
        }

    }
}
