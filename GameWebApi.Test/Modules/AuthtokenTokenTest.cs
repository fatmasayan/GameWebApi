using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Text;

namespace GameWebApi.Test;

public class AuthtokenTokenTest : BaseTestFactory
{
    public AuthtokenTokenTest(WebApplicationFactory<Program> factory) : base(factory)
    {
    }

    [Theory]
    [InlineData("/api/AuthtokenToken/getList")] //listeleme işlemi başarılı sonuçlanırsa
    public async Task GetAll_EndpointsReturnSuccess(string url)
    {
        _client.DefaultRequestHeaders.Add("Authorization", _token);
        var response = await _client.GetAsync(url);


        response.EnsureSuccessStatusCode();

        Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

    }

    [Theory] //listeleme testi başarısız sonuçlanırsa
    [InlineData("/api/AuthtokenToken/getList")]
    public async Task GetAll_EndpointsReturnFaild(string url)
    {
        var response = await _client.GetAsync(url);


        Assert.NotEqual(HttpStatusCode.OK, response.StatusCode);
    }


    [Theory]
    [InlineData("/api/AuthtokenToken/add")] //ekleme işlemi başarılı sonuçlanırsa
    public async Task Add_EndpointsReturnSuccess(string url)

    {
        _client.DefaultRequestHeaders.Add("Authorization", _token);
        var response = await _client.PostAsync(url, new StringContent(@"
{
  ""key"": ""string"",
  ""created"": ""2024-03-11T10:40:58.468Z"",
  ""user_id"": 0
}
", Encoding.UTF8, "application/json"));


        response.EnsureSuccessStatusCode();

        Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Theory]
    [InlineData("/api/AuthtokenToken/add")] //ekleme işlemi başarısız sonuçlanırsa
    public async Task Add_EndpointsReturnFaild(string url)
    {
        var response = await _client.PostAsync(url, new StringContent(@"", Encoding.UTF8, "application/json"));


        Assert.NotEqual(HttpStatusCode.OK, response.StatusCode);
    }


    [Theory]
    [InlineData("/api/AuthtokenToken/update")] //update başarılı sonuçlanırsa
    public async Task Update_EndpointsReturnSuccess(string url)
    {
        _client.DefaultRequestHeaders.Add("Authorization", _token);
        var response = await _client.PutAsync(url, new StringContent(@"
{
  ""key"": ""eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VyTmFtZSI6InVzZXIyIiwibmJmIjoxNzEzNDE3NDYyLCJleHAiOjE3MTM0Mjk0NjIsImlzcyI6Iklzc3VlckluZm9ybWF0aW9uIiwiYXVkIjoiQXVkaWVuY2VJbmZvcm1hdGlvbiJ9.ODBO4KcIV2CGYs0JgtOKPkDP2bRfccxCps-R80xlIbY"",
  ""created"": ""2024-03-11T10:40:58.468Z"",
  ""user_id"": 7
}
", Encoding.UTF8, "application/json"));


        response.EnsureSuccessStatusCode();

        Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

    }

    [Theory]
    [InlineData("/api/AuthtokenToken/update")]
    public async Task Update_EndpointsReturnFaild(string url) //update başarısız sonuçlanırsa 
    {
        var response = await _client.PutAsync(url, new StringContent(@"", Encoding.UTF8, "application/json"));


        Assert.NotEqual(HttpStatusCode.OK, response.StatusCode);
    }

    [Theory]
    [InlineData("/api/AuthtokenToken/delete")] //delete başarılı sonuçlanırsa
    public async Task Delete_EndpointsReturnSuccess(string url)
    {
        _client.DefaultRequestHeaders.Add("Authorization", _token);
        var response = await _client.DeleteAsync(url + "/eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VyTmFtZSI6InVzZXI0IiwibmJmIjoxNzEzNDE3NDgxLCJleHAiOjE3MTM0Mjk0ODEsImlzcyI6Iklzc3VlckluZm9ybWF0aW9uIiwiYXVkIjoiQXVkaWVuY2VJbmZvcm1hdGlvbiJ9.STKsdh3_sbxZKjCzGzSug70PvpigfCZ23Ly3WN6a4Eg");


        response.EnsureSuccessStatusCode();

        Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Theory]
    [InlineData("/api/AuthtokenToken/delete")] //delete başarısız sonuçlanırsa
    public async Task Delete_EndpointsReturnFaild(string url)
    {
        var response = await _client.DeleteAsync(url);

        Assert.NotEqual(HttpStatusCode.OK, response.StatusCode);
    }

}
