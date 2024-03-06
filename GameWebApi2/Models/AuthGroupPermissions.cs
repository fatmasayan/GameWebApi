namespace GameWebApi2.Models;

public class AuthGroupPermissions : BaseEntity
{
    public int id { get; set; }
    public AuthGroup group { get; set; }
    public int group_id { get; set; }
    public AuthPermission permission { get; set; }
    public int permission_id { get; set; }
}


