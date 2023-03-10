using ActumDigitalDemo.Frameworks.Attributes;
using ActumDigitalDemo.Selenium;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Diagnostics;

namespace ActumDigitalDemo.PageObjects;

public class HomePage : BasePage
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

    public void ChangeCategoryWithWait(string categoryName) { //find out something smarter in cooperation with devs

        var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));

        switch (categoryName.ToLowerInvariant()) {
            case "phones":
                Categories.ToList()[0].Click();
                wait.Until(_ => Products.First().Name.Text.ToLowerInvariant().Contains("samsung"));
                break;
            case "laptops":
                Categories.ToList()[1].Click();
                wait.Until(_ => Products.First().Name.Text.ToLowerInvariant().Contains("sony"));
                break;
            case "monitors":
                Categories.ToList()[2].Click();
                wait.Until(_ => Products.First().Name.Text.ToLowerInvariant().Contains("apple"));
                break;
            default:
                throw new Exception("unknown category name"); //TODO create custom exception
        }
    }

    public string AcceptSuccessAlert() {
        var nape = new NoAlertPresentException();

        var stopwatch = Stopwatch.StartNew();
        while (stopwatch.Elapsed < TimeSpan.FromSeconds(5)) {
            try {
                var alert = webDriver.SwitchTo().Alert();
                var returnText = alert.Text;
                alert.Accept();
                return returnText;
            }
            catch (NoAlertPresentException ex) {
                nape = ex;
            }
        }

        throw nape;
    }
}