namespace GameWebApi2.ViewModels;

public class UserBikesViewModel
{
    //public int id { get; set; }
    public bool isActive { get; set; }
    public BikeParts body { get; set; }
    public BikeParts handlebar { get; set; }
    public BikeParts indicator { get; set; }
    public AuthUser loginUser { get; set; }
    public BikeParts saddle { get; set; }
    public BikeParts wheel { get; set; }
}
