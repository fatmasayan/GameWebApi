using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Text;

namespace GameWebApi.Test;

public class LoginTest : BaseTestFactory
{
    public LoginTest(WebApplicationFactory<Program> factory) : base(factory)
    {
    }

    [Theory]
    [InlineData("/api/Login/LoginUser")]
    public async Task Get_EndpointsReturnSuccess(string url)
    {
        var response = await _client.PostAsync(url, new StringContent(@"
{
    ""username"":""user4"",
    ""password"":""4""
}
",Encoding.UTF8,"application/json"));

        // Assert
        response.EnsureSuccessStatusCode();
        //var result = await response.Content.ReadAsStringAsync(); // bu satırı test amaçlı koymuştum sonucu görmek için yani. 
        Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString()); // sonucun tipine bakarak başarılı olup olmadığı kontrol edilir başarılı ise OK
    }

    [Theory]
    [InlineData("/api/Login/LoginUser")]
    public async Task Get_EndpointsReturnFailed(string url)
    {
        //Act
        var response = await _client.PostAsync(url, new StringContent(@"",Encoding.UTF8,"application/json"));

        // Assert 
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode); // sonucun Status Koduna bakılır ve sonuç 400 dönmüşse OK
    }
}

