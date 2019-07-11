using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using System;

namespace SsauScheduleTest
{
    [TestClass]
    public class SsauSchedileTest
    {
        [TestMethod]
        public void SsauSiteShouldOpenScheduleOfGroup()
        {
            using (var driver = new ChromeDriver(AppDomain.CurrentDomain.BaseDirectory))
            {
                // arrange
                var group = "6313-020302D";
                var startPage = new SsauStartPage(driver);
                // act
                var resultPage = startPage.GoToScheduleSearchPage();
                // assert
                Assert.IsTrue(resultPage.CanFoundScheduleOfGroup(group));
            }
        }
        [TestMethod]
        [DataRow("154684")]
        [DataRow("6666")]
        public void SsauSiteShouldNotOpenScheduleOfGroup(string group)
        {
            using (var driver = new ChromeDriver(AppDomain.CurrentDomain.BaseDirectory))
            {
                // arrange
                var startPage = new SsauStartPage(driver);
                // act
                var resultPage = startPage.GoToScheduleSearchPage();
                // assert
                Assert.IsFalse(resultPage.CanFoundScheduleOfGroup(group));
            }
        }
    }
}
