using ActumDigitalDemo.Frameworks.Attributes;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace ActumDigitalDemo.Selenium;

public class BasePage
{
    protected readonly IWebDriver webDriver;
    public HeaderComponent Header;

    [FindsById("navbarExample")]
    private IWebElement HeaderElement;

    protected string url;

    public BasePage() {
        webDriver = GlobalWebDriverHooks.GetWebDriver();
        PageFactory.InitElements(webDriver, this);
        Header = new HeaderComponent(webDriver, HeaderElement);
    }

    public void Navigate() {
        webDriver.Navigate().GoToUrl(url);
    }
}