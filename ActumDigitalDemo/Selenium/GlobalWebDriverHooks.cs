using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ActumDigitalDemo.Selenium;

[Binding]
internal class GlobalWebDriverHooks
{
    private static IWebDriver webDriver;

    public static IWebDriver GetWebDriver() {
        return webDriver ??= new ChromeDriver();
    }

    [BeforeScenario]
    public static void Init() {
        webDriver = new ChromeDriver();
        webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        webDriver.Manage().Window.Maximize();
    }

    private static readonly long testRunNumber = DateTimeOffset.Now.ToUnixTimeSeconds();
    private static long screenNumberCounter;

    [AfterStep()]
    public static void makeScreenshot(FeatureContext featureContext, ScenarioContext scenarioContext) {

        var parentFolder = DateTime.Now.ToString("dd'-'MM");
        var screenName = scenarioContext.StepContext.StepInfo.Text;

        var dir = Path.Combine("screenshots", parentFolder, testRunNumber.ToString(), featureContext.FeatureInfo.Title);
        Directory.CreateDirectory(dir);

        var screenshot = ((ITakesScreenshot)webDriver).GetScreenshot();
        screenshot.SaveAsFile($"{dir}/{screenName}.png", ScreenshotImageFormat.Png);
    }

    [AfterScenario]
    public static void TearDown() {
        webDriver.Manage().Cookies.DeleteAllCookies();
        webDriver?.Quit();
        webDriver?.Dispose();
    }
}