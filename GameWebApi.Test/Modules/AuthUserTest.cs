using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;

namespace GameWebApi.Test.Modules;

public class AuthUserTest : BaseTestFactory
{
    public AuthUserTest(WebApplicationFactory<Program> factory) : base(factory)
    {
    }

    [Theory]
    [InlineData("/api/AuthUser/getList")]
    public async Task Get_EndpointsReturnSuccess(string url)
    {
        _client.DefaultRequestHeaders.Add("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VyTmFtZSI6InVzZXI5IiwibmJmIjoxNzEzMTc2MDAyLCJleHAiOjE3MTMxODgwMDIsImlzcyI6Iklzc3VlckluZm9ybWF0aW9uIiwiYXVkIjoiQXVkaWVuY2VJbmZvcm1hdGlvbiJ9.Wdm67cvxtjfmoQjsuoWlT9Li9yrCS4_4lxP5gCk4usQ");
        var response = await _client.GetAsync(url);

        // Assert
        response.EnsureSuccessStatusCode();
        //var result = await response.Content.ReadAsStringAsync(); // bu satırı test amaçlı koymuştum sonucu görmek için yani. 
        Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString()); // sonucun tipine bakarak başarılı olup olmadığı kontrol edilir başarılı ise OK
        Assert.Equal(HttpStatusCode.OK, response.StatusCode); // sonucun Status Koduna bakılır ve sonuç 200 dönmüşse OK

        // 2 tane Assert eklendiği için ikisini de sağlayınca test başarılı oluyor.
    }
}
