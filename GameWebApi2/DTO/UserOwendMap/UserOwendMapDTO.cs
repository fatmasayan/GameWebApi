﻿namespace GameWebApi2.DTO;

public class UserOwendMapDTO
{
    //public int id { get; set; }
    public int totalPlayed { get; set; } //count m
    public DateTime createDate { get; set; }
    public DateTime changeDate { get; set; }
    public int loginUser_id { get; set; }
    public int map_id { get; set; }
    public int totalKM { get; set; }
}
