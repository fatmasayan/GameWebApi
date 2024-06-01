using Microsoft.AspNetCore.Mvc.Testing;

namespace GameWebApi.Test;

public class BaseTestFactory : IClassFixture<WebApplicationFactory<Program>>
{
    protected readonly WebApplicationFactory<Program> _factory;
    protected HttpClient _client;
    protected string _token;

    public BaseTestFactory(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
        _client = factory.CreateClient();
        _client.BaseAddress = new Uri("http://localhost:5099");
        _token = "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VyTmFtZSI6InVzZXI1IiwibmJmIjoxNzEzNDE1MzU5LCJleHAiOjE3MTM0MjczNTksImlzcyI6Iklzc3VlckluZm9ybWF0aW9uIiwiYXVkIjoiQXVkaWVuY2VJbmZvcm1hdGlvbiJ9.kmUh9JlA8kpz5rKUF6iU0Wl8sXn2v7TYwT6XH2T5ZkU";
    }
}

/*
 djangocontetntype getallsuccess
django migrations getendpoinsucces
userowendachi getsuccess
 
 
 */