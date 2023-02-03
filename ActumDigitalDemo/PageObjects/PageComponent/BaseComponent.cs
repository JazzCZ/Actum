using OpenQA.Selenium;

namespace ActumDigitalDemo.Selenium;

internal class BaseComponent
{
    protected ISearchContext SearchContext { get; }
    protected IWebDriver WebDriver { get; }

    public BaseComponent(IWebDriver webDriver, ISearchContext context) 
    {
        WebDriver = webDriver;
        SearchContext = context;
    }
}