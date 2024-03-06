namespace GameWebApi2.Models;

public class UserProfile : BaseEntity
{
    public int id { get; set; }
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
    public AuthUser user { get; set; }  //tum ozellikleri al
}
