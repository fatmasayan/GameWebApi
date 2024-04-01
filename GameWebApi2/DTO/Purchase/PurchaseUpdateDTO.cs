namespace GameWebApi2.DTO;

public class PurchaseUpdateDTO
{
    public int id { get; set; }
    public string puchasedItem { get; set; }
    public DateTime date { get; set; }
    public int loginUser_id { get; set; }
}
