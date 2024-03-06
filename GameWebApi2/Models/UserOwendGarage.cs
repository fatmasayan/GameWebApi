namespace GameWebApi2.Models;

public class UserOwendGarage : BaseEntity
{
    public int id { get; set; }
    public bool isActive { get; set; }
    public DateTime createDate { get; set; }
    public int garage_id { get; set; }
    public Garage garage { get; set; }
    public int loginUser_id { get; set; }
    public AuthUser loginUser { get; set; }
}
