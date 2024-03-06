namespace GameWebApi2.Models;

public class UserOwnedAchievement : BaseEntity
{
    public int id { get; set; }
    public DateTime changeDate { get; set; }
    public int achievement_id { get; set; }
    public Achievement achievement { get; set; } //ach name
    public int loginUser_id { get; set; }
    public AuthUser loginUser { get; set; }
}
