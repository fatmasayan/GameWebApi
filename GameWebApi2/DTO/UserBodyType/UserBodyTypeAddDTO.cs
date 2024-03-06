namespace GameWebApi2.DTO;

public class UserBodyTypeAddDTO
{
    //public int id { get; set; }
    public int bodyType { get; set; }
    public bool isActive { get; set; }
    public DateTime date { get; set; }
    public int loginUser_id { get; set; }
    //public AuthUser loginUser { get; set; }// bunu burda açık bırakında tabloua ait nesneyi oluşturmayada izin vermiş oluruz
}
