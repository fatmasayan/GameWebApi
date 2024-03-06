using System.Security.Principal;

namespace GameWebApi2.Authentication;

public class BasicAuthenticationClient : IIdentity
{
    public BasicAuthenticationClient()
    {
    }

    public string? AuthenticationType { get; set; }

    public bool IsAuthenticated { get; set; }

    public string? Name {  get; set; }
}
