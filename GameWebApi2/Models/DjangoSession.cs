using System.ComponentModel.DataAnnotations;

namespace GameWebApi2.Models;

public class DjangoSession : BaseEntity
{
    [Key]
    public string session_key { get; set; }  //primary key
    public string session_data { get; set; }
    public  DateTime expire_date { get; set; }
}
