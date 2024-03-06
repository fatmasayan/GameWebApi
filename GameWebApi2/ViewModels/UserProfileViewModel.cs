namespace GameWebApi2.ViewModels;

public class UserProfileViewModel
{
    //public int id { get; set; }
    public string nickName { get; set; }
    public int sex { get; set; } // boolaen
    public DateTime birthDate { get; set; }
    public double weight { get; set; }
    public double height { get; set; }
    public int bodyType { get; set; }
    public string country { get; set; }
    public string city { get; set; }
    public string address { get; set; }
    public DateTime changeDate { get; set; }
    public int user_id { get; set; }
}
