using System.Net;

namespace Customers.Api.Tests.Integration;

public sealed class CustomerControllerTests
{
    [Fact]
    public async Task Get_Should_ReturnNotFound_When_CustomerDoesNotExist()
    {
        // Arrange
        var httpClient = new HttpClient()
        {
            BaseAddress = new Uri("https://localhost:5001")
        };

        // Act
        var response = await httpClient.GetAsync($"customers/{ Guid.NewGuid() }");

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
}