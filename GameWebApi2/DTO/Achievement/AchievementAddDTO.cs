namespace GameWebApi2.DTO;

public class AchievementAddDTO
{
    public string achievementName { get; set; }
    public string goalName { get; set; }
    public DateTime changeDate { get; set; }
}
// model üzerinde direkt işlem yapılmaması ve gereken durumlara özel modeller oluşturabilmek için, ekleme ,güncelleme ve silme için modeller oluşturulur.
// Models are created for additions, updates and deletions in order not to perform direct operations on the model and to create custom models when necessary.