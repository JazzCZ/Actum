using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ActumDigitalDemo.Selenium;

[Binding]
internal class GlobalSetup
{
    private static IWebDriver webDriver;

    public static IWebDriver GetWebDriver() {
        return webDriver ??= new ChromeDriver();
    }

    [BeforeTestRun]
    public static void Init() {
        webDriver = new ChromeDriver();
        webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        webDriver.Manage().Window.Maximize();
    }

    [AfterTestRun]
    public static void TearDown() {
        webDriver?.Quit();
        webDriver?.Dispose();
    }
}