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
}