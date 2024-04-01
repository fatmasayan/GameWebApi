using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GameWebApi2;

public class TokenService : ITokenService
{
    private readonly IConfiguration configuration;

    public TokenService(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    public Task<GenerateTokenResponse> GenerateToken(GenerateTokenRequest request)
    {
        SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["AppSettings:Secret"]));

        var tokenExpirationSeconds = int.Parse(configuration["AppSettings:Expiration"]);
        //var expires = dateTimeNow.AddSeconds(tokenExpirationSeconds);


        var dateTimeNow = DateTime.UtcNow;

        var expires = dateTimeNow.AddSeconds(tokenExpirationSeconds);

        JwtSecurityToken jwt = new JwtSecurityToken(
                issuer: configuration["AppSettings:ValidIssuer"],
                audience: configuration["AppSettings:ValidAudience"],
                claims: new List<Claim> {
                    new Claim("userName", request.Username)
                },
                notBefore: dateTimeNow,
                expires: expires,
                signingCredentials: new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256)
            );

        return Task.FromResult(new GenerateTokenResponse
        {
            Token = new JwtSecurityTokenHandler().WriteToken(jwt),
            TokenExpireDate = expires
        });
    }

    public bool ValidateToken(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(configuration["AppSettings:Secret"]);
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero
        };

        try
        {
            tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken validatedToken);
            return true; // Token geçerli ise
        }
        catch
        {
            return false; // Token geçersiz
        }
    }
}


