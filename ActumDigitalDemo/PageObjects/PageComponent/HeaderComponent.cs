using ActumDigitalDemo.Frameworks.Attributes;
using ActumDigitalDemo.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace ActumDigitalDemo.Selenium;

public class HeaderComponent : BaseComponent
{
    [FindsById("nameofuser")]
    public IWebElement LoggedUserName { get; set; }

    [FindsById("cartur")]
    private IWebElement CartLink { get; set; }

    [FindsById("login2")]
    private IWebElement LoginLink { get; set; }

    [FindsById("logout2")]
    private IWebElement LogoutLink { get; set; }

    [FindsById("signin2")]
    private IWebElement SignUpLink { get; set; }

    private LogInModalForm LogInForm;

    [FindsById("logInModal")]
    private IWebElement logInModal;

    [FindsById("signInModal")]
    private IWebElement signInModal;

    private SignUpModalForm SingUpForm;

    public HeaderComponent(IWebDriver webDriver, ISearchContext context) : base(webDriver, context) { }

    public SignUpModalForm SingUp() {
        SignUpLink.Click();
        SingUpForm = new SignUpModalForm(WebDriver, WebDriver);
        return SingUpForm;
    }

    public LogInModalForm LogIn() {
        LoginLink.Click();
        LogInForm = new LogInModalForm(WebDriver, WebDriver);
        return LogInForm;
    }

    public CartPage NavigatetoCart() {
        CartLink.Click();
        return new CartPage();
    }

    public bool LoggedUserNameIsVisible() {
        var wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(5));
        wait.Until(ExpectedConditions.ElementIsVisible(By.Id("nameofuser")));
        return true;
    }
}