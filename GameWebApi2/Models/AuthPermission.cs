namespace GameWebApi2.Models;

public class AuthPermission : BaseEntity
{
    public int id {  get; set; }
    public int content_type_id { get; set; }
    public string codename { get; set; }
    public string name { get; set; }
}
