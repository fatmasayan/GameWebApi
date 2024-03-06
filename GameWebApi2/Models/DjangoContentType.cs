namespace GameWebApi2.Models;

public class DjangoContentType : BaseEntity
{
    public int id {  get; set; }
    public string app_label { get; set; }
    public string model { get; set; }
    

}
