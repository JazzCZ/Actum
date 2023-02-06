using ActumDigitalDemo.Extensions;
using ActumDigitalDemo.PageObjects;
using ActumDigitalDemo.Selenium;
using FluentAssertions;

namespace ActumDigitalDemo.Steps;

[Binding]
public class UserManagementStepDefinitions
{
    private readonly ScenarioContext _scenarioContext;

    public UserManagementStepDefinitions(ScenarioContext scenarioContext) {
        _scenarioContext = scenarioContext;
    }

    [When(@"user use sing up in header")]
    public void WhenUserUseSingUpInHeader() {
        var page = _scenarioContext.GetCurrentPage<HomePage>();
        var singUpForm = page.Header.SingUp();
        _scenarioContext.SetCurrentComponent(singUpForm);
    }

    [When(@"user fill new username")]
    public void WhenUserFillNewUsername() {
        var usernameToRegister = $"{DateTimeOffset.Now.ToUnixTimeMilliseconds()}@testmail.com";

        var singUpForm = _scenarioContext.GetCurrentComponent<SignUpModalForm>();
        singUpForm.UsernameInput.SendKeys(usernameToRegister);
    }

    [When(@"user fill new password")]
    public void WhenUserFillNewPassword() {
        var usernameToRegisterPassword = "supersecret";

        var singUpForm = _scenarioContext.GetCurrentComponent<SignUpModalForm>();
        singUpForm.PasswordInput.SendKeys(usernameToRegisterPassword);
    }

    [When(@"user confirm sing up")]
    public void WhenUserConfirmSingUp() {
        var singUpForm = _scenarioContext.GetCurrentComponent<SignUpModalForm>();
        singUpForm.ConfirmButton.Click();
    }

    [Then(@"user can see successful sign up")]
    public void ThenUserCanSeeSuccessfulSignUp() {
        var page = _scenarioContext.GetCurrentPage<HomePage>();
        page.SingUpModalIsVisible().Should().BeTrue();
    }

    [Then(@"user is logged in")]
    public void ThenUserIsLoggedIn() {
        var page = _scenarioContext.GetCurrentPage<HomePage>();
        page.Header.LoggedUserNameIsVisible().Should().BeTrue();
        page.Header.LoggedUserName.Text.Should().Be($"Welcome {Users.commonUser.email}");
    }

    [When(@"user click on login button")]
    public void WhenUserClickOnLoginButton() {
        var page = _scenarioContext.GetCurrentPage<HomePage>();
        var loginForm = page.Header.LogIn();
        _scenarioContext.SetCurrentComponent(loginForm);
    }

    [When(@"user fill username")]
    public void WhenUserFillUsername() {
        var loginForm = _scenarioContext.GetCurrentComponent<LogInModalForm>();
        loginForm.UsernameInput.SendKeys(Users.commonUser.email);
    }

    [When(@"user fill password")]
    public void WhenUserFillPassword() {
        var loginForm = _scenarioContext.GetCurrentComponent<LogInModalForm>();
        loginForm.PasswordInput.SendKeys(Users.commonUser.password);
    }

    [When(@"user click on log in")]
    public void WhenUserClickOnLogIn() {
        var loginForm = _scenarioContext.GetCurrentComponent<LogInModalForm>();
        loginForm.ConfirmButton.Click();
    }
}

public static class Users
{
    public static User commonUser = new User("a@b.c", "abc");
}

public class User
{
    public string email;
    public string password;

    public User(string email, string password) {
        this.email = email;
        this.password = password;
    }
}