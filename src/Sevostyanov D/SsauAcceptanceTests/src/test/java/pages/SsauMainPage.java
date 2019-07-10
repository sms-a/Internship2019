package pages;


import org.openqa.selenium.Keys;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.remote.RemoteWebDriver;

public class SsauMainPage extends BasePage {

    private static String SSAU_SITE_URL = "https://ssau.ru";
    private static String STUDENT_HELP_BUTTON_SELECTOR = "body > header > div.content-main > section > div.header-top > div.top-menu > ul > li:nth-child(2) > a";

    // button in menu that should navigate to page with help for students
    private WebElement studentButton;

    public SsauMainPage(RemoteWebDriver driver) {
        super(driver);

        openPage(SSAU_SITE_URL);
    }

    /**
     * Navigate to ssau.ru/student page
     * @return student help page
     */
    public SsauStudentHelpPage navigateToStudentsHelps() {
        clickOnStudentHelp();

        return new SsauStudentHelpPage(driver);
    }



    // click on "Студенту" button
    private void clickOnStudentHelp() {
        studentButton = findElementByCss(STUDENT_HELP_BUTTON_SELECTOR);
        studentButton.sendKeys(Keys.RETURN);
    }
}
