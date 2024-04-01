namespace GameWebApi2.DTO;

public class DjangoSessionUpdateDTO
{
    public string session_key { get; set; }  //primary key
    public string session_data { get; set; }
    public DateTime expire_date { get; set; }
}
