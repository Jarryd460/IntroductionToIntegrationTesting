using System.Collections;
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

    // [Theory(Skip = "This doesn't work atm sorry")]
    [Theory]
    [InlineData("0BFF56C1-8EE0-4013-BB64-89E0398FB629", Skip = "This doesn't work atm sorry")]
    [InlineData("032D4670-095B-4C67-830E-78C00C095507")]
    [InlineData("B8CAEF16-365F-4595-B55E-BCB69FF2260D")]
    [MemberData(nameof(Data))]
    [ClassData(typeof(ClassData))]
    public async Task Get_Should_ReturnNotFound_When_CustomerDoesNotExist2(string guidAsText)
    {
        // Arrange

        // Act
        var response = await httpClient.GetAsync($"customers/{ Guid.Parse(guidAsText) }");

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact(Skip = "This doesn't work atm sorry")]
    public async Task Get_Should_ReturnNotFound_When_CustomerDoesNotExist3()
    {
        // Arrange

        // Act
        var response = await httpClient.GetAsync($"customers/{ Guid.NewGuid() }");

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    public static IEnumerable<object[]> Data { get; } = new[] {
        new[] { "0CBADD64-F7E8-4DA8-B18A-A827CF64CA6C" },
        new[] { "26BC1565-5623-4B4A-94BF-2A5538031813" },
        new[] { "822838F5-4798-4268-AFC7-49EA1BB16AD9" }
    };

    public async Task InitializeAsync()
    {
        // Asynchronous setup code here
        await Task.Delay(1000);
    }
}

public class ClassData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { "FB4259CC-4481-466C-89D5-0A1194CB13AE" };
        yield return new object[] { "BB954D23-91B8-49A9-8BF8-A331492AF015" };
        yield return new object[] { "7C231A7D-25D7-4917-AA39-7A37AC05E772" };
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}