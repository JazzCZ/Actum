﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ActumDigitalDemo.Selenium;

[Binding]
internal class GlobalSetup
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

    [AfterScenario]
    public static void TearDown() {
        webDriver.Manage().Cookies.DeleteAllCookies();
        webDriver?.Quit();
        webDriver?.Dispose();
    }
}