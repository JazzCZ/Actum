using ActumDigitalDemo.Frameworks.Attributes;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace ActumDigitalDemo.Selenium;

internal class HeaderComponent : BaseComponent
{
    private SignUpModalForm SingUpForm;
    private LogInModalForm LogInForm;


    [FindsById("cartur")]
    public IWebElement CartLink { get; set; }

    [FindsById("nameofuser")]
    public IWebElement LoggedUserName { get; set; }

    [FindsById("login2")]
    private IWebElement LoginLink { get; set; }

    [FindsById("logout2")]
    private IWebElement LogoutLink { get; set; }
    
    [FindsById("signin2")]
    private IWebElement SignUpLink { get; set; }

    [FindsById("signInModal")]
    private IWebElement signInModal;
    
    [FindsById("logInModal")]
    private IWebElement logInModal;

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
}