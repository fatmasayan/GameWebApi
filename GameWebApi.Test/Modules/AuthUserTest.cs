using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Text;

namespace GameWebApi.Test;

public class AuthUserTest : BaseTestFactory
{
    public AuthUserTest(WebApplicationFactory<Program> factory) : base(factory)
    {
    }


    [Theory]
    [InlineData("/api/AuthUser/getList")] //listeleme işlemi başarılı sonuçlanırsa
    public async Task GetAll_EndpointsReturnSuccess(string url)
    {
        _client.DefaultRequestHeaders.Add("Authorization", _token);
        var response = await _client.GetAsync(url);


        response.EnsureSuccessStatusCode();

        Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

    }

    [Theory] //listeleme testi başarısız sonuçlanırsa
    [InlineData("/api/AuthUser/getList")]
    public async Task GetAll_EndpointsReturnFaild(string url)
    {
        var response = await _client.GetAsync(url);


        Assert.NotEqual(HttpStatusCode.OK, response.StatusCode);
    }



    [Theory]
    [InlineData("/api/AuthUser/getSingle")] //get single başarılı sonuçlanırsa
    public async Task Get_EndpointsReturnSuccess(string url)
    {
        _client.DefaultRequestHeaders.Add("Authorization", _token);
        var response = await _client.GetAsync(url + "/3");


        response.EnsureSuccessStatusCode();

        Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

    }

    [Theory]
    [InlineData("/api/AuthUser/getSingle")] // getsingle başarısız sonuçlanırsa
    public async Task Get_EndpointsReturnFaild(string url)
    {
        var response = await _client.GetAsync(url);


        Assert.NotEqual(HttpStatusCode.OK, response.StatusCode);

    }

    [Theory]
    [InlineData("/api/AuthUser/add")] //ekleme işlemi başarılı sonuçlanırsa
    public async Task Add_EndpointsReturnSuccess(string url)

    {
        _client.DefaultRequestHeaders.Add("Authorization", _token);
        var response = await _client.PostAsync(url, new StringContent(@"
{
  ""password"": ""testpass"",
  ""last_login"": ""2024-03-11T10:41:49.585Z"",
  ""is_superuser"": true,
  ""username"": ""testuser"",
  ""last_name"": ""t_user"",
  ""email"": ""t_mail"",
  ""is_staff"": true,
  ""is_active"": true,
  ""date_joined"": ""2024-03-11T10:41:49.585Z"",
  ""first_name"": ""test""
}
", Encoding.UTF8, "application/json"));


        response.EnsureSuccessStatusCode();

        Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Theory]
    [InlineData("/api/AuthUser/add")] //ekleme işlemi başarısız sonuçlanırsa
    public async Task Add_EndpointsReturnFaild(string url)
    {
        var response = await _client.PostAsync(url, new StringContent(@"", Encoding.UTF8, "application/json"));


        Assert.NotEqual(HttpStatusCode.OK, response.StatusCode);
    }


    [Theory]
    [InlineData("/api/AuthUser/update")] //update başarılı sonuçlanırsa
    public async Task Update_EndpointsReturnSuccess(string url)
    {
        _client.DefaultRequestHeaders.Add("Authorization", _token);
        var response = await _client.PutAsync(url, new StringContent(@"
{
  ""id"": 9,
  ""password"": ""güncellendi"",
  ""last_login"": ""2024-03-11T10:41:49.585Z"",
  ""is_superuser"": true,
  ""username"": ""güncellendi"",
  ""last_name"": ""güncellendi"",
  ""email"": ""güncellendi"",
  ""is_staff"": true,
  ""is_active"": true,
  ""date_joined"": ""2024-03-11T10:41:49.585Z"",
  ""first_name"": ""güncellendi""
}
", Encoding.UTF8, "application/json"));


        response.EnsureSuccessStatusCode();

        Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

    }

    [Theory]
    [InlineData("/api/AuthUser/update")]
    public async Task Update_EndpointsReturnFaild(string url) //update başarısız sonuçlanırsa 
    {
        var response = await _client.PutAsync(url, new StringContent(@"", Encoding.UTF8, "application/json"));


        Assert.NotEqual(HttpStatusCode.OK, response.StatusCode);
    }

    [Theory]
    [InlineData("/api/AuthUser/delete")] //delete başarılı sonuçlanırsa
    public async Task Delete_EndpointsReturnSuccess(string url)
    {
        _client.DefaultRequestHeaders.Add("Authorization", _token);
        var response = await _client.DeleteAsync(url + "/19");


        response.EnsureSuccessStatusCode();

        Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Theory]
    [InlineData("/api/AuthUser/delete")] //delete başarısız sonuçlanırsa
    public async Task Delete_EndpointsReturnFaild(string url)
    {
        var response = await _client.DeleteAsync(url);

        Assert.NotEqual(HttpStatusCode.OK, response.StatusCode);
    }
}
