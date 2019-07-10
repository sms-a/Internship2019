package pages;

import org.openqa.selenium.Keys;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.remote.RemoteWebDriver;

public class SsauStudentHelpPage extends BasePage {

    private static String TIMETABLE_LIST_ELEMENT_SELECTOR =
            "body > div:nth-child(5) > div:nth-child(1) > div > div:nth-child(2) > ul > li:nth-child(1) > a";

    private WebElement timetableListElement;

    public SsauStudentHelpPage(RemoteWebDriver driver) {
        super(driver);
    }

    /**
     * Click on list element named "Расписание занятий" that should navigate to ssau.ru/rasp
     * @return timetables page
     */
    public SsauTimetablesPage clickOnTimetableListElement() {
        timetableListElement = findElementByCss(TIMETABLE_LIST_ELEMENT_SELECTOR);
        timetableListElement.sendKeys(Keys.RETURN);

        return new SsauTimetablesPage(driver);
    }
}
