namespace GameWebApi2.Mapping;

public class AchievementProfile :Profile
{
    public AchievementProfile() //constructor
    {
        CreateMaps();
    }

    private void CreateMaps()
    {
        CreateMap<Achievement, AchievementViewModel>();
        // Converting the achievement model (Achievement) to a viewmodel (AchievementViewModel) to use it in operations such as listing
        //asıl modeli (Achievement), listeleme gibi işlemlerde kullanmak için (AchievementViewModel) viewmodel'e dönüştürme işlemi

        CreateMap<AchievementDTO, Achievement>();
        // converting the custom created model (AchievementDTO) to the original model (AchievementDTO)
        // özel oluşturulan modeli (AchievementDTO), asıl modele dönüştürme işlemi (AchievementDTO)


        CreateMap<AchievementAddDTO, Achievement>();
        // convert the model used in the add operation (AchievementAddDTO) to the actual model (Achievement)
        // ekleme işleminde kullanılan modeli (AchievementAddDTO), asıl modele dönüştürme işlemi (Achievement)


        CreateMap<AchievementUpdateDTO, Achievement>();
        // convert the model used for the update operation (AchievementUpdateDTO) to the actual model (Achievement)
        // güncelleme işlemi için kullanılan modeli (AchievementUpdateDTO) , asıl modele dönüştürme işlemi (Achievement)

    }

}
