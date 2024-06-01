using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Text;

namespace GameWebApi.Test;

public class UserBikesTest : BaseTestFactory
{
    public UserBikesTest(WebApplicationFactory<Program> factory) : base(factory)
    {
    }

    [Theory]
    [InlineData("/api/UserBikes/getList")] //listeleme işlemi başarılı sonuçlanırsa
    public async Task GetAll_EndpointsReturnSuccess(string url)
    {
        _client.DefaultRequestHeaders.Add("Authorization", _token);
        var response = await _client.GetAsync(url);

        
        response.EnsureSuccessStatusCode();

        Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString()); 
        Assert.Equal(HttpStatusCode.OK, response.StatusCode); 

    }

    [Theory] //listeleme testi başarısız sonuçlanırsa
    [InlineData("/api/UserBikes/getList")]
    public async Task GetAll_EndpointsReturnFaild(string url)
    {
        var response = await _client.GetAsync(url);

        
        Assert.NotEqual(HttpStatusCode.OK, response.StatusCode);
    }



    [Theory]
    [InlineData("/api/UserBikes/getSingle")] //get single başarılı sonuçlanırsa
    public async Task Get_EndpointsReturnSuccess(string url)
    {
        _client.DefaultRequestHeaders.Add("Authorization", _token);
        var response = await _client.GetAsync(url + "/3");

        
        response.EnsureSuccessStatusCode();

        Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

    }

    [Theory]
    [InlineData("/api/UserBikes/getSingle")] // getsingle başarısız sonuçlanırsa
    public async Task Get_EndpointsReturnFaild(string url)
    {
        var response = await _client.GetAsync(url);

         
        Assert.NotEqual(HttpStatusCode.OK, response.StatusCode); 

    }

    [Theory]
    [InlineData("/api/UserBikes/add")] //ekleme işlemi başarılı sonuçlanırsa
    public async Task Add_EndpointsReturnSuccess(string url)

    {
        _client.DefaultRequestHeaders.Add("Authorization", _token);
        var response = await _client.PostAsync(url, new StringContent(@"
{
    ""isActive"": false,
    ""body_id"": 1,
    ""handlebar_id"": 2,
    ""indicator_id"": 5,
    ""loginUser_id"": 2,
    ""saddle_id"": 3,
    ""wheel_id"": 4
}
", Encoding.UTF8, "application/json"));


        response.EnsureSuccessStatusCode();
        
        Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Theory]
    [InlineData("/api/UserBikes/add")] //ekleme işlemi başarısız sonuçlanırsa
    public async Task Add_EndpointsReturnFaild(string url)
    {
        var response = await _client.PostAsync(url, new StringContent(@"", Encoding.UTF8, "application/json"));


        Assert.NotEqual(HttpStatusCode.OK, response.StatusCode);
    }


    [Theory]
    [InlineData("/api/UserBikes/update")] //update başarılı sonuçlanırsa
    public async Task Update_EndpointsReturnSuccess(string url)
    {
        _client.DefaultRequestHeaders.Add("Authorization", _token);
        var response = await _client.PutAsync(url, new StringContent(@"
{
    ""id"": 19,
    ""isActive"": false,
    ""body_id"": 1,
    ""handlebar_id"": 2,
    ""indicator_id"": 5,
    ""loginUser_id"": 2,
    ""saddle_id"": 3,
    ""wheel_id"": 4
}
", Encoding.UTF8, "application/json"));

        
        response.EnsureSuccessStatusCode();

        Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

    }

    [Theory]
    [InlineData("/api/UserBikes/update")]
    public async Task Update_EndpointsReturnFaild(string url) //update başarısız sonuçlanırsa 
    {
        var response = await _client.PutAsync(url, new StringContent(@"", Encoding.UTF8, "application/json"));


        Assert.NotEqual(HttpStatusCode.OK, response.StatusCode);
    }

    [Theory]
    [InlineData("/api/UserBikes/delete")] //delete başarılı sonuçlanırsa
    public async Task Delete_EndpointsReturnSuccess(string url)
    {
        _client.DefaultRequestHeaders.Add("Authorization", _token);
        var response = await _client.DeleteAsync(url + "/21");

        
        response.EnsureSuccessStatusCode();

        Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Theory]
    [InlineData("/api/UserBikes/delete")] //delete başarısız sonuçlanırsa
    public async Task Delete_EndpointsReturnFaild(string url)
    {
        var response = await _client.DeleteAsync(url);

        Assert.NotEqual(HttpStatusCode.OK, response.StatusCode); 
    }
}
