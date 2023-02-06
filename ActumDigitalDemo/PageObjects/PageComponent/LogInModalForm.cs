using ActumDigitalDemo.Frameworks.Attributes;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace ActumDigitalDemo.Selenium;

public class LogInModalForm : BaseComponent
{
    [FindsBySequence]
    [FindsById("logInModal")]
    [FindsByCss(".btn-primary")]
    public IWebElement ConfirmButton;

    [FindsById("loginpassword")]
    public IWebElement PasswordInput;

    [FindsById("loginusername")]
    public IWebElement UsernameInput;

    public LogInModalForm(IWebDriver webDriver, ISearchContext context) : base(webDriver, context) { }
}