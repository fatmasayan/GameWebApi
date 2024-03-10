namespace GameWebApi2;

public interface ITokenService
{
    public Task<GenerateTokenResponse> GenerateToken(GenerateTokenRequest request);
}
