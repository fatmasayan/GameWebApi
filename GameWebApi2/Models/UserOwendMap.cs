namespace GameWebApi2.Models;

public class UserOwendMap : BaseEntity
{
    public int id { get; set; }
    public int totalPlayed { get; set; } //count m
    public DateTime createDate { get; set; }
    public DateTime changeDate { get; set; }
    public int loginUser_id { get; set; }
    public AuthUser loginUser { get; set; } // a+p g id 
    public int map_id { get; set; }
    public Map map { get; set; } // map-name
    public int totalKM { get; set; }
    
    
}
