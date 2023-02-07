using System.Net;
using FluentAssertions;

namespace ApiTests.Tests.Auth;

public class CreateToken
{
    public const string BaseUrl = "https://restful-booker.herokuapp.com/auth";
    public HttpClient Client;

    [SetUp]
    public void Setup() {
        Client = new HttpClient();
    }

    [Test]
    public async Task WhenCredentialsAreCorrect_ThenTokenIsObtained() {
        var values = new Dictionary<string, string> { { "username", "admin" }, { "password", "password123" } };
        var content = new FormUrlEncodedContent(values);

        var response = await Client.PostAsync(BaseUrl, content);
        var responseString = await response.Content.ReadAsStringAsync();
        response.StatusCode.ToString().Should().Be("OK");
        responseString.Should().Contain("token");
    }

    [Test]
    public async Task WhenCredentialsAreWrong_ThenErrorBadCredentials() {
        var values = new Dictionary<string, string> { { "username", "ad" }, { "password", "pa" } };
        var content = new FormUrlEncodedContent(values);

        var response = await Client.PostAsync(BaseUrl, content);
        var responseString = await response.Content.ReadAsStringAsync();

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(responseString, Contains.Substring("Bad credentials"));
    }

    [Test]
    public async Task WhenCredentialsAreWrong_ThenError() {
        var values = new Dictionary<string, string> { { "param1", "ad" } };
        var content = new FormUrlEncodedContent(values);

        var response = await Client.PostAsync(BaseUrl, content);
        var responseString = await response.Content.ReadAsStringAsync();

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(responseString, Contains.Substring("Bad credentials"));
    }
}