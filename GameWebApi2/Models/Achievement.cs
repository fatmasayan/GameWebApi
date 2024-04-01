namespace GameWebApi2.Models;

public class Achievement : BaseEntity
{
    public int id { get; set; } 
    public string achievementName { get; set; }
    public string goalName { get; set; }
    public DateTime changeDate { get; set; }
    //modelin tanımlanması
    //veri tabanındaki  tablo değişkenlerinin adı ve değişken tipleri ile aynı olmalı 
}
