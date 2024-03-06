﻿namespace GameWebApi2.Models;

public class Prices : BaseEntity
{
    public int id { get; set; }
    public string category { get; set; }
    public string item { get; set; }
    public int condition { get; set; }
    public int price1 { get; set; }
    public int price2 { get; set; }
    public string achievementCondition { get; set; }
}
