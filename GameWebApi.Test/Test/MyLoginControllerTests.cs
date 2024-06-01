using GameWebApi2;
using GameWebApi2.Controllers;
using GameWebApi2.Models;
using GameWebApi2.Repository;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace GameWebApi.Test;

public class MyLoginControllerTests
{
    LoginController _controller;
    IAuthService _service;

    //public MyLoginControllerTests(LoginController controller, IAuthService service)
    //{
    //    _service = new AuthService(new AuthUserRepository());
    //    _controller = new LoginController(_service);
    //}

    //[Fact]
    //public async void LoginUserAsync_ValidCredentials_ReturnsUserLoginResponse()
    //{
       
    //}
}