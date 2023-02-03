using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace ActumDigitalDemo.Frameworks.Attributes;

[Binding]
internal class FindsByCssAttribute : AbstractFindsByAttribute
{
    public override By Finder => By.CssSelector(_cssSelector);
    private readonly string _cssSelector;

    public FindsByCssAttribute(string cssSelector) 
    {
        _cssSelector = cssSelector;
    }
}