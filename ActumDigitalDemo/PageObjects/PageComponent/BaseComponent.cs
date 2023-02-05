using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace ActumDigitalDemo.Selenium;

internal class BaseComponent
{
    protected ISearchContext SearchContext { get; }
    protected IWebDriver WebDriver { get; }

    public BaseComponent(IWebDriver webDriver, ISearchContext context) {
        WebDriver = webDriver;
        SearchContext = context;
        PageFactory.InitElements(context, this);
    }
}