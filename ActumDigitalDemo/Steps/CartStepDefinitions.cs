using ActumDigitalDemo.Extensions;
using ActumDigitalDemo.PageObjects;
using ActumDigitalDemo.Selenium;
using FluentAssertions;

namespace ActumDigitalDemo.Steps;

[Binding]
public class CartStepDefinitions
{
    private const string ProductNameInCartKey = "productNameInCart";
    private readonly ScenarioContext _scenarioContext;

    public CartStepDefinitions(ScenarioContext scenarioContext) {
        _scenarioContext = scenarioContext;
    }

    [Given(@"user is logged in")]
    public void GivenUserIsLoggedIn() {
        var page = _scenarioContext.GetCurrentPage<HomePage>();
        var modal = page.Header.LogIn();
        modal.UsernameInput.SendKeys(Users.commonUser.email);
        modal.PasswordInput.SendKeys(Users.commonUser.password);
        modal.ConfirmButton.Click();
        page.Header.LoggedUserNameIsVisible();
    }

    [Given(@"user is on '([^']*)' category")]
    public void GivenUserIsOnCategory(string categoryName) {
        var page = _scenarioContext.GetCurrentPage<HomePage>();
        page.ChangeCategoryWithWait(categoryName);
    }

    [When(@"user select first product")]
    public void WhenUserSelectFirstProduct() {
        var page = _scenarioContext.GetCurrentPage<HomePage>();
        _scenarioContext.Add(ProductNameInCartKey, page.Products.First().Name.Text);
        var detailPage = page.Products.First().OpenDetailPage();
        _scenarioContext.SetCurrentPage(detailPage);
    }

    [When(@"user put goods in cart")]
    public void WhenUserPutGoodsInCart() {
        var page = _scenarioContext.GetCurrentPage<ProductDetailPage>();
        page.AddProductToCart();
    }

    [When(@"user navigates to cart")]
    public void WhenUserNavigatesToCart() {
        var page = _scenarioContext.GetCurrentPage<BasePage>();
        var cartPage = page.Header.NavigatetoCart();
        _scenarioContext.SetCurrentPage(cartPage);
    }

    [Then(@"user can see his products in cart page")]
    public void ThenUserCanSeeHisProductsInCartPage() {
        var page = _scenarioContext.GetCurrentPage<CartPage>();
        page.productsInCart.Text.Should().Contain(_scenarioContext.Get<string>(ProductNameInCartKey)); //TODO change cart to grid and iterate
    }

    [When(@"user select second product")]
    public void WhenUserSelectSecondProduct() {
        throw new PendingStepException();
    }
}