﻿namespace GameWebApi2.Models;

public class UserBodyType : BaseEntity //elle değişim
{
    public int id { get; set; }
    public int bodyType { get; set; }
    public bool isActive { get; set; }
    public DateTime date { get; set; }
    public int loginUser_id { get; set; }
    public AuthUser loginUser { get; set; }

}
