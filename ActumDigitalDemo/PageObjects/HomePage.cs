using ActumDigitalDemo.Frameworks.Attributes;
using ActumDigitalDemo.Selenium;
using OpenQA.Selenium;

namespace ActumDigitalDemo.PageObjects;

internal class HomePage : BasePage
{
    // [FindsAllById("itemc")] //TODO needs to implement tag that will return collection
    // public IEnumerable<IWebElement> Categories { get; set; }
    public IEnumerable<IWebElement> Categories => webDriver.FindElements(By.Id("itemc"));

    public IEnumerable<ProductComponent> Products => ProductsArea.FindElements(By.CssSelector(".col-lg-4")).Select(x => new ProductComponent(webDriver, x));

    [FindsById("tbodyid")]
    private IWebElement ProductsArea;

    public HomePage() {
        url = "https://www.demoblaze.com/index.html";
    }
}