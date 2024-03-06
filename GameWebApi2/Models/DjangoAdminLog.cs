namespace GameWebApi2.Models;

public class DjangoAdminLog : BaseEntity
{
    public int id { get; set; }
    public string object_id { get; set; }
    public string object_repr { get; set; }
    public int action_flag { get; set; }
    public string change_message { get; set; }
    public int content_type_id { get; set; }
    public DjangoContentType content_type { get; set; }
    public int user_id { get; set; }
    public AuthUser user { get; set; }
    public DateTime action_time { get; set; }
}
