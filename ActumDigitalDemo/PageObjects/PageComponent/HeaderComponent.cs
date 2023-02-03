using ActumDigitalDemo.Frameworks.Attributes;
using OpenQA.Selenium;

namespace ActumDigitalDemo.Selenium;

internal class HeaderComponent : BaseComponent
{
    [FindsById("login2")]
    private IWebElement LoginLink { get; set; }

    [FindsById("logout2")]
    private IWebElement LogoutLink { get; set; }

    [FindsById("signin2")]
    private IWebElement SignInLink { get; set; }

    [FindsById("nameofuser")]
    public IWebElement LoggedUserName { get; set; }

    [FindsById("cartur")]
    public IWebElement CartLink { get; set; }

    public HeaderComponent(IWebDriver webDriver, ISearchContext context) : base(webDriver, context)
    {
    }
}