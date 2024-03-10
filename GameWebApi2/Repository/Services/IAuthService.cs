namespace GameWebApi2;

public interface IAuthService
{
    public Task<UserLoginResponse> LoginUserAsync(UserLoginRequest request);
}

