namespace GameWebApi2.DTO;

public class UserOwnedAchievementUpdateDTO
{
    public int id { get; set; }
    public DateTime changeDate { get; set; }
    public int achievement_id { get; set; }
    public int loginUser_id { get; set; }
}
