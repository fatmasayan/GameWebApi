namespace GameWebApi2.Models;

public class DjangoMigrations : BaseEntity
{
    public int id { get; set; }
    public string app {  get; set; }
    public string name {  get; set; }
    public DateTime applied {  get; set; }

}
