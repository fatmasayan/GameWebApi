namespace GameWebApi2.Models;

public class AuthUserGroups : BaseEntity
{
    public int id { get; set; }
    public int user_id { get; set; }
    public AuthUser user { get; set; }
    public int group_id { get; set; } // bunun için de yap 
    public AuthGroup group { get; set; }
}
