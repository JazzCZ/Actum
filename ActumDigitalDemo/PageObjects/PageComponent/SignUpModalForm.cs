using ActumDigitalDemo.Frameworks.Attributes;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace ActumDigitalDemo.Selenium;

public class SignUpModalForm : BaseComponent
{
    [FindsBySequence]
    [FindsById("signInModal")]
    [FindsByCss(".btn-primary")]
    public IWebElement ConfirmButton;

    [FindsById("sign-password")]
    public IWebElement PasswordInput;

    [FindsById("sign-username")]
    public IWebElement UsernameInput;

    public SignUpModalForm(IWebDriver webDriver, ISearchContext context) : base(webDriver, context) { }
}