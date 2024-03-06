using Microsoft.AspNetCore.Authorization;

namespace GameWebApi2.Authentication;

public class BasicAuthorizationAttribute : AuthorizeAttribute
{
    public BasicAuthorizationAttribute()
    {
        AuthenticationSchemes = "Basic";
    }
}
