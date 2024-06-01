using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GameWebApi.Test;

public class DjangoMigrationsTest : BaseTestFactory
{
    public DjangoMigrationsTest(WebApplicationFactory<Program> factory) : base(factory)
    {
    }


    [Theory]
    [InlineData("/api/DjangoMigrations/getList")] //listeleme işlemi başarılı sonuçlanırsa
    public async Task GetAll_EndpointsReturnSuccess(string url)
    {
        _client.DefaultRequestHeaders.Add("Authorization", _token);
        var response = await _client.GetAsync(url);


        response.EnsureSuccessStatusCode();

        Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

    }

    [Theory] //listeleme testi başarısız sonuçlanırsa
    [InlineData("/api/DjangoMigrations/getList")]
    public async Task GetAll_EndpointsReturnFaild(string url)
    {
        var response = await _client.GetAsync(url);


        Assert.NotEqual(HttpStatusCode.OK, response.StatusCode);
    }



    [Theory]
    [InlineData("/api/DjangoMigrations/getSingle")] //get single başarılı sonuçlanırsa
    public async Task Get_EndpointsReturnSuccess(string url)
    {
        _client.DefaultRequestHeaders.Add("Authorization", _token);
        var response = await _client.GetAsync(url + "/2");


        response.EnsureSuccessStatusCode();

        Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

    }

    [Theory]
    [InlineData("/api/DjangoMigrations/getSingle")] // getsingle başarısız sonuçlanırsa
    public async Task Get_EndpointsReturnFaild(string url)
    {
        var response = await _client.GetAsync(url);


        Assert.NotEqual(HttpStatusCode.OK, response.StatusCode);

    }

    [Theory]
    [InlineData("/api/DjangoMigrations/add")] //ekleme işlemi başarılı sonuçlanırsa
    public async Task Add_EndpointsReturnSuccess(string url)

    {
        _client.DefaultRequestHeaders.Add("Authorization", _token);
        var response = await _client.PostAsync(url, new StringContent(@"
{
  ""app"": ""test_ekleme"",
  ""name"": ""string"",
  ""applied"": ""2024-03-11T10:50:49.891Z""
}
", Encoding.UTF8, "application/json"));


        response.EnsureSuccessStatusCode();

        Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Theory]
    [InlineData("/api/DjangoMigrations/add")] //ekleme işlemi başarısız sonuçlanırsa
    public async Task Add_EndpointsReturnFaild(string url)
    {
        var response = await _client.PostAsync(url, new StringContent(@"", Encoding.UTF8, "application/json"));


        Assert.NotEqual(HttpStatusCode.OK, response.StatusCode);
    }


    [Theory]
    [InlineData("/api/DjangoMigrations/update")] //update başarılı sonuçlanırsa
    public async Task Update_EndpointsReturnSuccess(string url)
    {
        _client.DefaultRequestHeaders.Add("Authorization", _token);
        var response = await _client.PutAsync(url, new StringContent(@"
{
  ""id"": 27,
  ""app"": ""test_güncelleme"",
  ""name"": ""string"",
  ""applied"": ""2024-03-11T10:50:49.891Z""
}
", Encoding.UTF8, "application/json"));


        response.EnsureSuccessStatusCode();

        Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

    }

    [Theory]
    [InlineData("/api/DjangoMigrations/update")]
    public async Task Update_EndpointsReturnFaild(string url) //update başarısız sonuçlanırsa 
    {
        var response = await _client.PutAsync(url, new StringContent(@"", Encoding.UTF8, "application/json"));


        Assert.NotEqual(HttpStatusCode.OK, response.StatusCode);
    }

    [Theory]
    [InlineData("/api/DjangoMigrations/delete")] //delete başarılı sonuçlanırsa
    public async Task Delete_EndpointsReturnSuccess(string url)
    {
        _client.DefaultRequestHeaders.Add("Authorization", _token);
        var response = await _client.DeleteAsync(url + "/28");


        response.EnsureSuccessStatusCode();

        Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Theory]
    [InlineData("/api/DjangoMigrations/delete")] //delete başarısız sonuçlanırsa
    public async Task Delete_EndpointsReturnFaild(string url)
    {
        var response = await _client.DeleteAsync(url);

        Assert.NotEqual(HttpStatusCode.OK, response.StatusCode);
    }
}
