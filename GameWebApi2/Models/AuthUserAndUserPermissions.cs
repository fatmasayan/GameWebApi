namespace GameWebApi2.Models;

public class AuthUserAndUserPermissions : BaseEntity
{
    public int id {  get; set; }
    public int user_id { get; set; }
    public AuthUser user { get; set; }
    public int permission_id { get; set; }
    public AuthPermission permission { get; set; }

}
