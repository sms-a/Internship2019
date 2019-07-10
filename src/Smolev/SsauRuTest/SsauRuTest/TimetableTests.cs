using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;

namespace SsauRuTest
{
    [TestClass]
    public class TimetableTests
    {
        [TestMethod]
        public void TimetableShouldExistForGroup6313()
        {
            var timetablePage = new TimetablePage(new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)), false);
            var group = "6313";

            bool isTimetableFound = timetablePage.FindGroupTimetableInGroupsListMenu(group);

            Assert.IsTrue(isTimetableFound);
            
        }

        [TestMethod]
        [DataRow("631", DisplayName = "Номер группы не введен полностью")]
        [DataRow("63131", DisplayName = "Нет такой группы")]
        [DataRow("4101", DisplayName = "Более одной группы с таким номером либо имеется более одного расписания для данной группы")]
        public void TimetableShouldNotExistForNonexistingOrDuplicateGroups(string group)
        {
            var timetablePage = new TimetablePage(new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)), false);
            
            bool isTimetableFound = timetablePage.FindGroupTimetableInGroupsListMenu(group);

            Assert.IsFalse(isTimetableFound);
        }

    }
}
