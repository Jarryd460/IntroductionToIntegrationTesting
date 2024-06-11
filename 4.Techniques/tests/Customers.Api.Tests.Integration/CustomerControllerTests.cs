using System.Collections;
using System.Net;
using System.Net.Http;
using Customers.Api;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Customers.Api.Tests.Integration;

public sealed class CustomerControllerTests : IClassFixture<WebApplicationFactory<IApiMarker>>
{
    private readonly HttpClient _httpClient;

    public CustomerControllerTests(WebApplicationFactory<IApiMarker> webApplicationFactory)
    {
        _httpClient = webApplicationFactory.CreateClient();
    }

    [Fact]
    public async Task Get_Should_ReturnNotFound_When_CustomerDoesNotExist()
    {
        // Arrange

        // Act
        var response = await _httpClient.GetAsync($"customers/{ Guid.NewGuid() }");

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
}