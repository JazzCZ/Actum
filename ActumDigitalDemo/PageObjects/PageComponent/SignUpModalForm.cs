using ActumDigitalDemo.Frameworks.Attributes;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace ActumDigitalDemo.Selenium;

public class SignUpModalForm : BaseComponent
{
    [FindsById("sign-username")]
    public IWebElement UsernameInput;

    [FindsById("sign-password")]
    public IWebElement PasswordInput;

    [FindsBySequence]
    [FindsById("signInModal")]
    [FindsByCss(".btn-primary")]
    public IWebElement ConfirmButton;


    public SignUpModalForm(IWebDriver webDriver, ISearchContext context) : base(webDriver, context) { }
}