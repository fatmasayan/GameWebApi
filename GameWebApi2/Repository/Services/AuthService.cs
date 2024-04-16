using GameWebApi2.Models;

namespace GameWebApi2;

public class AuthService : IAuthService
{

    private readonly ITokenService tokenService;
    private readonly IAuthUserRepository authUserRepository;
    private readonly IAuthtokenTokenRepository authtokenTokenRepository;

    public AuthService(ITokenService tokenService, 
        IAuthUserRepository authUserRepository, 
        IAuthtokenTokenRepository authtokenTokenRepository)
    {
        this.tokenService = tokenService;
        this.authUserRepository = authUserRepository;
        this.authtokenTokenRepository = authtokenTokenRepository;
    }


    public async Task<UserLoginResponse> LoginUserAsync(UserLoginRequest request)
    {
        UserLoginResponse response = new();

        if (string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
        {
            throw new ArgumentNullException(nameof(request));
        }

        var user = authUserRepository.Get(x => x.username == request.Username && x.password == request.Password);

        if (user != null)
        {
            // Yeni bir token oluştur ve kaydet
            var generatedTokenInformation = await tokenService.GenerateToken(new GenerateTokenRequest { Username = request.Username });

            response.AuthenticateResult = true;
            response.AuthToken = generatedTokenInformation.Token;
            response.AccessTokenExpireDate = generatedTokenInformation.TokenExpireDate;

            authtokenTokenRepository.Add(new AuthtokenToken
            {
                user_id = user.id,
                key = response.AuthToken,
                created = DateTime.Now
            });
        }

        return response;
    }

}

// 