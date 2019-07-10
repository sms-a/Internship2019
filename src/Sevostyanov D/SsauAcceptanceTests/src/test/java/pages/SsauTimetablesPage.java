package pages;

import org.openqa.selenium.Keys;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.remote.RemoteWebDriver;

import java.util.List;

public class SsauTimetablesPage extends BasePage {

    private static String GROUP_INPUT_SELECTOR = "#select2-timetableSelect-container > span";
    private static String OPENED_GROUP_INPUT_SELECTOR = "body > span > span > span.select2-search.select2-search--dropdown > input";

    // input field's design contains 2 state (unfocused/focused) that emulates by 2 different elements
    private WebElement groupInput;
    private WebElement openedInput;

    public SsauTimetablesPage(RemoteWebDriver driver) {
        super(driver);

        groupInput = findElementByCss(GROUP_INPUT_SELECTOR);
    }

    /**
     * @return input field
     */
    public WebElement getGroupInput() {
        return groupInput;
    }

    /**
     * Finds timetable by group id <br>
     *     Id format:
     *     <i>****-******L where * is number, L is letter</i>
     *     Sample:
     *     <i>6213-020302D</i>
     * @param groupId
     * @return result page
     */
    public SsauTimetableResultPage findTimetableByGroupId(String groupId) {
        clickOnGroupInput();

        openedInput.sendKeys(groupId);
        openedInput.click();
        openedInput.sendKeys(Keys.RETURN);

        return new SsauTimetableResultPage(driver);
    }

    // field should be clicked before start typing id
    private void clickOnGroupInput() {
        groupInput.click();

        openedInput = findElementByCss(OPENED_GROUP_INPUT_SELECTOR);
    }
}
