using System.ComponentModel.DataAnnotations;

namespace GameWebApi2.Models;

public class AuthtokenToken : BaseEntity
{
    [Key]
    public string key { get; set; } //primary key
    public DateTime created { get; set; }
    public int user_id { get; set; }
    public AuthUser user { get; set; }


}
