using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GameWebApi.Test;

public class DjangoAdminLogTest : BaseTestFactory
{
    public DjangoAdminLogTest(WebApplicationFactory<Program> factory) : base(factory)
    {
    }

    // sana dedim 
    [Theory]
    [InlineData("/api/DjangoAdminLog/getList")] //listeleme işlemi başarılı sonuçlanırsa
    public async Task GetAll_EndpointsReturnSuccess(string url)
    {
        _client.DefaultRequestHeaders.Add("Authorization", _token);
        var response = await _client.GetAsync(url);


        response.EnsureSuccessStatusCode();

        Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

    }

    [Theory] //listeleme testi başarısız sonuçlanırsa
    [InlineData("/api/DjangoAdminLog/getList")]
    public async Task GetAll_EndpointsReturnFaild(string url)
    {
        var response = await _client.GetAsync(url);


        Assert.NotEqual(HttpStatusCode.OK, response.StatusCode);
    }



    [Theory]
    [InlineData("/api/DjangoAdminLog/getSingle")] //get single başarılı sonuçlanırsa
    public async Task Get_EndpointsReturnSuccess(string url)
    {
        _client.DefaultRequestHeaders.Add("Authorization", _token);
        var response = await _client.GetAsync(url + "/4");


        response.EnsureSuccessStatusCode();

        Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

    }

    [Theory]
    [InlineData("/api/DjangoAdminLog/getSingle")] // getsingle başarısız sonuçlanırsa
    public async Task Get_EndpointsReturnFaild(string url)
    {
        var response = await _client.GetAsync(url);


        Assert.NotEqual(HttpStatusCode.OK, response.StatusCode);

    }

    [Theory]
    [InlineData("/api/DjangoAdminLog/add")] //ekleme işlemi başarılı sonuçlanırsa
    public async Task Add_EndpointsReturnSuccess(string url)

    {
        _client.DefaultRequestHeaders.Add("Authorization", _token);
        var response = await _client.PostAsync(url, new StringContent(@"
{
  ""object_id"": ""test_ile_eklendi"",
  ""object_repr"": ""string"",
  ""action_flag"": 2,
  ""change_message"": ""string"",
  ""content_type_id"": 14,
  ""user"": 1,
  ""action_time"": ""2024-03-11T10:48:12.131Z""
}
", Encoding.UTF8, "application/json"));


        response.EnsureSuccessStatusCode();

        Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Theory]
    [InlineData("/api/DjangoAdminLog/add")] //ekleme işlemi başarısız sonuçlanırsa
    public async Task Add_EndpointsReturnFaild(string url)
    {
        var response = await _client.PostAsync(url, new StringContent(@"", Encoding.UTF8, "application/json"));


        Assert.NotEqual(HttpStatusCode.OK, response.StatusCode);
    }


    [Theory]
    [InlineData("/api/DjangoAdminLog/update")] //update başarılı sonuçlanırsa
    public async Task Update_EndpointsReturnSuccess(string url)
    {
        _client.DefaultRequestHeaders.Add("Authorization", _token);
        var response = await _client.PutAsync(url, new StringContent(@"
{
  ""id"": 42,
  ""object_id"": ""ekle"",
  ""object_repr"": ""test_ile güncelle"",
  ""action_flag"": 1,
  ""change_message"": ""string"",
  ""content_type_id"": 11,
  ""user"": 1,
  ""action_time"": ""2024-03-11T10:48:12.131Z""
}
", Encoding.UTF8, "application/json"));


        response.EnsureSuccessStatusCode();

        Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

    }

    [Theory]
    [InlineData("/api/DjangoAdminLog/update")]
    public async Task Update_EndpointsReturnFaild(string url) //update başarısız sonuçlanırsa 
    {
        var response = await _client.PutAsync(url, new StringContent(@"", Encoding.UTF8, "application/json"));


        Assert.NotEqual(HttpStatusCode.OK, response.StatusCode);
    }

    [Theory]
    [InlineData("/api/DjangoAdminLog/delete")] //delete başarılı sonuçlanırsa
    public async Task Delete_EndpointsReturnSuccess(string url)
    {
        _client.DefaultRequestHeaders.Add("Authorization", _token);
        var response = await _client.DeleteAsync(url + "/40");


        response.EnsureSuccessStatusCode();

        Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Theory]
    [InlineData("/api/DjangoAdminLog/delete")] //delete başarısız sonuçlanırsa
    public async Task Delete_EndpointsReturnFaild(string url)
    {
        var response = await _client.DeleteAsync(url);

        Assert.NotEqual(HttpStatusCode.OK, response.StatusCode);
    }
}
