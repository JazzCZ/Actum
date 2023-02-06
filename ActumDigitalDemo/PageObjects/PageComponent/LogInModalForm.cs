using ActumDigitalDemo.Frameworks.Attributes;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace ActumDigitalDemo.Selenium;

public class LogInModalForm : BaseComponent
{
    [FindsById("loginusername")]
    public IWebElement UsernameInput;
    
    [FindsById("loginpassword")]
    public IWebElement PasswordInput;

    [FindsBySequence]
    [FindsById("logInModal")]
    [FindsByCss(".btn-primary")]
    public IWebElement ConfirmButton;


    public LogInModalForm(IWebDriver webDriver, ISearchContext context) : base(webDriver, context) { }
}