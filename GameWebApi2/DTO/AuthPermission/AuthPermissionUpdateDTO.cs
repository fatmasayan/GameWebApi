namespace GameWebApi2.DTO;

public class AuthPermissionUpdateDTO
{
    public int id { get; set; }
    public int content_type_id { get; set; }
    public string codename { get; set; }
    public string name { get; set; }
}
