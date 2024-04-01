namespace GameWebApi2.DTO;

public class AchievementAddDTO
{
    public string achievementName { get; set; }
    public string goalName { get; set; }
    public DateTime changeDate { get; set; }
}
//model üzüerinde direkt işlem yapılmaması ve gerek durumlara özel modeller oluşturabilmek adına ekleme güncelleme ve silme için modeller oluşturulur.