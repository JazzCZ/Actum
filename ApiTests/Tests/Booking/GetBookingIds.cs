using FluentAssertions;

namespace ApiTests.Tests;

public class GetBookingIds
{
    public const string BaseUrl = "https://restful-booker.herokuapp.com/booking";
    public HttpClient Client;

    [SetUp]
    public void Setup() {
        Client = new HttpClient();
    }

    [Test]
    public async Task WhenCalledGetBookingsIds_ThenIdsAreObtained() {
        var response = await Client.GetAsync(BaseUrl);
        var responseString = await response.Content.ReadAsStringAsync();

        response.StatusCode.ToString().Should().Be("OK");
        responseString.Should().Contain("booking"); //better to serialize to Json and crawl through Json
    }

    [Test]
    public async Task WhenBookingsIdsAreFilteredByName_ThenFilteredSubsetOfBookingsAreObtained() {
        var response = await Client.GetAsync($"{BaseUrl}?firstname=sally&lastname=brown");
        var responseString = await response.Content.ReadAsStringAsync();

        response.StatusCode.ToString().Should().Be("OK");
        responseString.Should().Contain("booking"); //does not work because its empty, I do not know correct filter
    }

    [Test]
    public async Task WhenBookingsIdsAreFilteredByWrongNames_ThenFilteredSubsetOfBookingsIsEmpty() {
        var response = await Client.GetAsync($"{BaseUrl}?firstname=sally&lastname=brown");
        var responseString = await response.Content.ReadAsStringAsync();

        response.StatusCode.ToString().Should().Be("OK");
        responseString.Should().Be("[]");
    }

    [Test]
    public async Task WhenBookingsIdsAreFilteredByChecking_ThenFilteredSubsetOfBookingsAreObtained() {
        var response = await Client.GetAsync($"{BaseUrl}?checkin=2014-03-13&checkout=2014-05-21");
        var responseString = await response.Content.ReadAsStringAsync();

        response.StatusCode.ToString().Should().Be("OK");
        responseString.Should().Contain("booking"); //does not work because its empty, I do not know correct filter
    }

    public async Task WhenBookingsIdsAreFilteredByWrongCheckin_ThenFilteredSubsetOfBookingsIsEmpty() {
        var response = await Client.GetAsync($"{BaseUrl}?checkin=2014-03-13&checkout=2014-05-21");
        var responseString = await response.Content.ReadAsStringAsync();

        response.StatusCode.ToString().Should().Be("OK");
        responseString.Should().Contain("[]");
    }

    [Test]
    public async Task WhenBookingsIdsAreFilteredByInvalidData_ThenGetsInternalServerError() {
        var response = await Client.GetAsync($"{BaseUrl}?checkin=2014-03-133&checkout=2014-05-221");
        var responseString = await response.Content.ReadAsStringAsync();

        response.StatusCode.ToString().Should().Be("InternalServerError");
    }
}