import org.junit.Assert;
import org.junit.Test;
import org.openqa.selenium.chrome.ChromeDriver;
import org.openqa.selenium.chrome.ChromeDriverInfo;
import org.openqa.selenium.chrome.ChromeDriverService;
import org.openqa.selenium.chrome.ChromeOptions;
import pages.SsauMainPage;

import java.io.Closeable;

public class SsauSiteTests {

    /**
     * Acceptance test of searching timetable<br>
     * from site www.ssau.ru
     */
    @Test
    public void timetableSsauTest() {
        try(var driver = new CloseableChromeDriver()){
            // arrange
            var startPage = new SsauMainPage(driver);

            // act
            var studentsHelps = startPage.navigateToStudentsHelps();
            var timetablesPage = studentsHelps.clickOnTimetableListElement();
            var resultPage = timetablesPage.findTimetableByGroupId("6213-020302D");

            // assert
            Assert.assertNotNull(resultPage.getTimetable());
        }
    }

    // fix for try-with-resources
    private class CloseableChromeDriver extends ChromeDriver implements Closeable {
        public CloseableChromeDriver() {
            super();
        }

        @Override
        public void close() {
            super.quit();
        }
    }
}
