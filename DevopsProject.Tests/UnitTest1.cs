using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace DevopsProject.Tests;

public class ApiTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public ApiTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task Get_root_returns_200()
    {
        var response = await _client.GetAsync("/");
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task Get_products_returns_200()
    {
        var response = await _client.GetAsync("/products");
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}
