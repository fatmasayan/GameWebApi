namespace GameWebApi2.DTO;

public class DjangoMigrationsUpdateDTO
{
    public int id { get; set; }
    public string app { get; set; }
    public string name { get; set; }
    public DateTime applied { get; set; }
}
