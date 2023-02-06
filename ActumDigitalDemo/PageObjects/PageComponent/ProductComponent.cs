using ActumDigitalDemo.Frameworks.Attributes;
using ActumDigitalDemo.PageObjects;
using OpenQA.Selenium;

namespace ActumDigitalDemo.Selenium;

public class ProductComponent : BaseComponent
{
    [FindsById("article")]
    public IWebElement Description;

    [FindsByCss(".card-title")]
    public IWebElement Name;

    [FindsByCss(".card-img-top")]
    public IWebElement Picture;

    [FindsByCss(".card-block > h5")]
    public IWebElement Price;

    public ProductComponent(IWebDriver webDriver, ISearchContext context) : base(webDriver, context) { }

    public ProductDetailPage OpenDetailPage() {
        Name.Click();
        return new ProductDetailPage();
    }
}