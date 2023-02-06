using System.Diagnostics;
using ActumDigitalDemo.Frameworks.Attributes;
using ActumDigitalDemo.Selenium;
using NUnit.Framework;
using OpenQA.Selenium;

namespace ActumDigitalDemo.PageObjects;

public class ProductDetailPage : BasePage
{
    [FindsByCss(".btn-success")]
    private IWebElement AddToCartButton { get; set; }

    public void AddProductToCart() {
        var nape = new NoAlertPresentException();

        AddToCartButton.Click();
        var stopwatch = Stopwatch.StartNew();
        while (stopwatch.Elapsed < TimeSpan.FromSeconds(5)) {
            try {
                var alert = webDriver.SwitchTo().Alert();
                alert.Accept();
                return;
            }
            catch (NoAlertPresentException ex) {
                nape = ex;
            }
        }
        throw nape;
    }
}