using System.Text.RegularExpressions;
using ActumDigitalDemo.Extensions;
using ActumDigitalDemo.PageObjects;
using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform;
using static NUnit.Framework.Internal.OSPlatform;

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
        page.ChangeCategoryWithWait(categoryName);
    }

    [Then(@"user can see '([^']*)'")]
    public void ThenUserCanSee(string productType) {
        var page = _scenarioContext.GetCurrentPage<HomePage>();
        page.Products.Should().HaveCountGreaterThan(0);

        switch (productType.ToLowerInvariant()) {
            case "phones":
                page.Products.First().Name.Text.Should().Contain("Samsung");
                break;
            case "laptops":
                page.Products.First().Name.Text.Should().Contain("Sony");
                break;
            case "monitors":
                page.Products.First().Name.Text.Should().Contain("monitor");
                break;
            default:
                throw new Exception("unknown product type"); //TODO create custom exception
        }
    }

    [Then(@"user can see price")]
    public void ThenUserCanSeePrice() {
        var page = _scenarioContext.GetCurrentPage<HomePage>();
        var currecnyAndDigitsRegex = new Regex("\\$\\d+");
        page.Products.First().Price.Text.Should().MatchRegex(currecnyAndDigitsRegex);
    }
}