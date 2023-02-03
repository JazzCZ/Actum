using ActumDigitalDemo.Extensions;
using ActumDigitalDemo.PageObjects;

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
                page.Categories[0].Click();
                break;
            case "laptops":
                page.Categories[1].Click();
                break;
            case "monitors":
                page.Categories[2].Click();
                break;
            default:
                throw new Exception("unknown category name"); //TODO create custom exception
        }
    }

    [Then(@"user can see '([^']*)'")]
    public void ThenUserCanSee(string phones) {
        throw new PendingStepException();
    }

    [Then(@"user can see images")]
    public void ThenUserCanSeeImages() {
        throw new PendingStepException();
    }
}