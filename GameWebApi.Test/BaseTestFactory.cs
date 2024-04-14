using Microsoft.AspNetCore.Mvc.Testing;

namespace GameWebApi.Test;

public class BaseTestFactory : IClassFixture<WebApplicationFactory<Program>>
{
    protected readonly WebApplicationFactory<Program> _factory;
    protected HttpClient _client;

    public BaseTestFactory(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
        _client = factory.CreateClient();
        _client.BaseAddress = new Uri("http://localhost:5099");
    }
}
