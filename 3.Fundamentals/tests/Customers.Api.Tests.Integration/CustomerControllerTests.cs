using System.Net;

namespace Customers.Api.Tests.Integration;

public sealed class CustomerControllerTests : IAsyncLifetime, IDisposable
{
    private readonly HttpClient httpClient = new HttpClient()
    {
        BaseAddress = new Uri("https://localhost:5001")
    };

    public CustomerControllerTests()
    {
        // Setup code here        
    }

    public void Dispose()
    {
        // Clean up code here
    }

    public async Task DisposeAsync()
    {
        // Clean up code here. This is if you require async/await otherwise inheriting from IDisposable
        // can also be used to cleanup code
        await Task.Delay(1000);
    }

    [Fact]
    public async Task Get_Should_ReturnNotFound_When_CustomerDoesNotExist()
    {
        // Arrange

        // Act
        var response = await httpClient.GetAsync($"customers/{ Guid.NewGuid() }");

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task Get_Should_ReturnNotFound_When_CustomerDoesNotExist2()
    {
        // Arrange

        // Act
        var response = await httpClient.GetAsync($"customers/{ Guid.NewGuid() }");

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    public async Task InitializeAsync()
    {
        // Asynchronous setup code here
        await Task.Delay(1000);
    }
}