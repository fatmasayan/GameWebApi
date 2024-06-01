using GameWebApi2.Controllers;
using GameWebApi2.Models;
using GameWebApi2;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace GameWebApi.Test;

public class LoginControllerTest
{
   
    [Fact]
    public async Task LoginUserAsync_Returns_UserLoginResponse()
    {
        // Arrange
        var authServiceMock = new Mock<IAuthService>(); 
        var expectedResponse = new UserLoginResponse {};
        authServiceMock.Setup(service => service.LoginUserAsync(It.IsAny<UserLoginRequest>())).ReturnsAsync(expectedResponse);

        var controller = new LoginController(authServiceMock.Object);
        var request = new UserLoginRequest { };

        // Act
        var result = await controller.LoginUserAsync(request);

        // Assert
        var actionResult = Assert.IsType<ActionResult<UserLoginResponse>>(result);
        var okObjectResult = Assert.IsType<OkObjectResult>(actionResult.Result);
        var model = Assert.IsType<UserLoginResponse>(okObjectResult.Value);
        Assert.Equal(expectedResponse, model);
    }
}
