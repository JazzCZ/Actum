using System.Text.RegularExpressions;
using ActumDigitalDemo.Extensions;
using ActumDigitalDemo.PageObjects;
using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform;

namespace ActumDigitalDemo.Steps;

[Binding]
public class ProductCategoriesStepDefinitions
{
    private readonly ScenarioContext _scenarioContext;

    public ProductCategoriesStepDefinitions(ScenarioContext scenarioContext) {
        _scenarioContext = scenarioContext;
    }

    [Given(@"user is on shop homepage")]
    public void GivenUserIsOnShopHomepage() {
        var page = new HomePage();
        page.Navigate();
        _scenarioContext["currentPage"] = page;
    }

    [When(@"user navigates to '([^']*)' category")]
    public void WhenUserNavigatesToCategory(string categoryName) {
        var page = _scenarioContext.GetCurrentPage<HomePage>();

        switch (categoryName.ToLowerInvariant()) {
            case "phones":
                page.Categories.ToList()[0].Click();
                break;
            case "laptops":
                page.Categories.ToList()[1].Click();
                break;
            case "monitors":
                page.Categories.ToList()[2].Click();
                break;
            default:
                throw new Exception("unknown category name"); //TODO create custom exception
        }
    }

    [Then(@"user can see '([^']*)'")]
    public void ThenUserCanSee(string productType) {
        var page = _scenarioContext.GetCurrentPage<HomePage>();
        page.Products.Should().HaveCountGreaterThan(0);
    }

    [Then(@"user can see price")]
    public void ThenUserCanSeePrice() {
        var page = _scenarioContext.GetCurrentPage<HomePage>();
        var currecnyAndDigitsRegex = new Regex("\\$\\d+");
        page.Products.First().Price.Text.Should().MatchRegex(currecnyAndDigitsRegex);
    }
}