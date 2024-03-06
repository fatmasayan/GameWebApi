using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;

namespace GameWebApi2.Authentication;

public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
    public BasicAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
    {

    }


    protected override Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        if (!Request.Headers.ContainsKey("Authorization"))
            return Task.FromResult(AuthenticateResult.Fail("Authorization key gerekiyor."));

        var authorization = Request.Headers["Authorization"].ToString();

        if(!authorization.StartsWith("Basic ", StringComparison.OrdinalIgnoreCase))
            return Task.FromResult(AuthenticateResult.Fail("Authorization 'Basic ' şeklinde başlamalıdır."));

        var authString = Encoding.UTF8.GetString(Convert.FromBase64String(authorization.Replace("Basic ", "", StringComparison.OrdinalIgnoreCase)));

        var authSplit = authString.Split(new[] { ':' }, 2); // username:password

        if (authSplit.Length != 2)
            return Task.FromResult(AuthenticateResult.Fail("Authorization düzgün formatta değil."));

        var clientId = authSplit[0];
        var clientSecret = authSplit[1];

        if(clientId != "dofrobotics" && clientSecret != "dof123")
            return Task.FromResult(AuthenticateResult.Fail("Kullanıcı adı veya şifre yanlış."));

        var client = new BasicAuthenticationClient
        {
            AuthenticationType = "Basic",
            IsAuthenticated = true,
            Name = clientId
        };

        var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(client, new[]
        {
            new Claim(ClaimTypes.Name, clientId), 
        }));

        return Task.FromResult(AuthenticateResult.Success(new AuthenticationTicket(claimsPrincipal,Scheme.Name)));
    }
}