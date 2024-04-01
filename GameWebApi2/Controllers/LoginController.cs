﻿namespace GameWebApi2.Controllers;

[Route("api/[controller]")]
[ApiController]
//[Authorize]
public class LoginController : ControllerBase
{
    private readonly IAuthService authService;

    public LoginController(IAuthService authService)
    {
        this.authService = authService;
    }


    [HttpPost("LoginUser")]
    [AllowAnonymous]
    public async Task<ActionResult<UserLoginResponse>> LoginUserAsync([FromBody] UserLoginRequest request)
    {
        var result = await authService.LoginUserAsync(request);
        return result;
    }

    


}
