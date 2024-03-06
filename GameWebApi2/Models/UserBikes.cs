namespace GameWebApi2.Models;

public class UserBikes : BaseEntity //b yi elle değiştim B
{
    public int id { get; set; } 
    public bool isActive { get; set; }
    public int body_id { get; set; }
    public BikeParts body { get; set; }
    public int handlebar_id { get; set; } 
    public BikeParts handlebar { get; set; } 
    public int indicator_id { get; set; } 
    public BikeParts indicator { get; set; }
    public int loginUser_id { get; set; }
    public AuthUser loginUser { get; set; }
    public int saddle_id { get; set; }
    public BikeParts saddle { get; set; }
    public int wheel_id { get; set; }
    public BikeParts wheel { get; set; }
      

}
