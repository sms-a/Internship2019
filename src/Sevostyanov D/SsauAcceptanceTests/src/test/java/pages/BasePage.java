package pages;

import org.openqa.selenium.By;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.remote.RemoteWebDriver;

import java.util.NoSuchElementException;
import java.util.concurrent.TimeUnit;

public class BasePage {

    protected RemoteWebDriver driver;

    public BasePage(RemoteWebDriver driver) {
        this.driver = driver;

        driver.manage().timeouts().implicitlyWait(10, TimeUnit.SECONDS);
        driver.manage().window().maximize();
    }

    public WebElement findElementByCss(String css) {
        WebElement element;

        try {
            element = driver.findElement(By.cssSelector(css));
        } catch (NoSuchElementException ex) {
            throw new NoSuchElementException("CSS selector = \"" + css + "\"\n");
        }

        return element;
    }

    public void openPage(String pagePath) {
        driver.navigate().to(pagePath);
    }
}
