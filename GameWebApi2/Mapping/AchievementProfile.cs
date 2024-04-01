namespace GameWebApi2.Mapping;

public class AchievementProfile :Profile
{
    public AchievementProfile() //constructor
    {
        CreateMaps();
    }

    private void CreateMaps()
    {
        CreateMap<Achievement, AchievementViewModel>(); //asıl modeli(Achievement), listeleme gbi işlemlerde  kullanmak için (AchievementViewModel)  dönüştürme işlemi
        CreateMap<AchievementDTO, Achievement>(); // özel oluşturlan modeli (AchievementDTO) asıl modele dönüştürme işlemi (AchievementDTO)

        CreateMap<AchievementAddDTO, Achievement>(); // ekleme işleminde kullanılan modeli (AchievementAddDTO), asıl modele dönüştürme işlemi (Achievement)

        CreateMap<AchievementUpdateDTO, Achievement>();  // güncelleme işlemi için kullanılan modeli (AchievementUpdateDTO) , asıl modele dönüştürme işlemi (Achievement)
        
    }

}
