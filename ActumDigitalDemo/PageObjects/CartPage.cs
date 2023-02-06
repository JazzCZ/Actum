using ActumDigitalDemo.Frameworks.Attributes;
using ActumDigitalDemo.Selenium;
using OpenQA.Selenium;

namespace ActumDigitalDemo.PageObjects;

public class CartPage : BasePage
{
    [FindsById("tbodyid")]
    public IWebElement productsInCart { get; set; }

}