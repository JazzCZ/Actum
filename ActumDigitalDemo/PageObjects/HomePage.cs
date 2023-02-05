using ActumDigitalDemo.Selenium;
using OpenQA.Selenium;

namespace ActumDigitalDemo.PageObjects;

internal class HomePage : BasePage
{
    // [FindsAllById("itemc")] //TODO needs to implement tag that will return collection
    // public IEnumerable<IWebElement> Categories { get; set; }
    public IEnumerable<IWebElement> Categories => webDriver.FindElements(By.Id("itemc"));

    public HomePage() {
        url = "https://www.demoblaze.com/index.html";
    }
}