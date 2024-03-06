namespace GameWebApi2.Models;

public class Purchase : BaseEntity
{
    public int id { get; set; }
    public string puchasedItem { get; set; }
    public DateTime date { get; set; }
    public int loginUser_id { get; set; }
    public AuthUser loginUser { get; set; } // a+p g id
}
