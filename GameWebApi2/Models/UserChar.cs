namespace GameWebApi2.Models;

public class UserChar : BaseEntity
{
    public int id { get; set; }
    public bool isSet { get; set; }
    public bool isActive { get; set; }
    public int body_id { get; set; } 
    public CharItems body { get; set; }
    public int foot_id { get; set; } //charitems
    public CharItems foot { get; set; }
    public int glove_id { get; set; } //charitems
    public CharItems glove { get; set; }
    public int head_id { get; set; } //charitems
    public CharItems head { get; set; }
    public int leg_id { get; set; } //charitems
    public CharItems leg { get; set; }
    public int loginUser_id { get; set; }
    public AuthUser loginUser { get; set; } //a+p g id
}
