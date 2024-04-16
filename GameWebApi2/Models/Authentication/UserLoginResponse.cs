namespace GameWebApi2.Models;

public class UserLoginResponse
{
    public bool AuthenticateResult { get; set; }
    public string AuthToken { get; set; }
    public DateTime AccessTokenExpireDate { get; set; } 
}
