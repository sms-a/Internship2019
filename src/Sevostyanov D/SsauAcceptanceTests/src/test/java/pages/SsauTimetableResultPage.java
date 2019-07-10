package pages;

import org.openqa.selenium.WebElement;
import org.openqa.selenium.remote.RemoteWebDriver;

public class SsauTimetableResultPage extends BasePage {

    private static String TIMETABLE_SELECTOR = "#myTabContent";

    // timetable of student's lessons
    private WebElement timetableElement;

    public SsauTimetableResultPage(RemoteWebDriver driver) {
        super(driver);

        timetableElement = findElementByCss(TIMETABLE_SELECTOR);
    }

    /**
     * Finds and returns timetable from page by css selector
     *
     * @return time table
     */
    public WebElement getTimetable() {
        return timetableElement;
    }
}
