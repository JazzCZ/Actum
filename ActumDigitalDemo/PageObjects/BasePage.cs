using ActumDigitalDemo.Frameworks.Attributes;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace ActumDigitalDemo.Selenium;

internal class BasePage
{
    protected string url;
    private IWebDriver webDriver;

    [FindsById("navbarExample")]
    private IWebElement HeaderElement;

    public HeaderComponent Header;

    public BasePage() {
        Header = new HeaderComponent(webDriver, HeaderElement);
        webDriver = GlobalSetup.GetWebDriver();

    }

    public void Navigate()
    {
        webDriver.Navigate().GoToUrl(url);
    }
}