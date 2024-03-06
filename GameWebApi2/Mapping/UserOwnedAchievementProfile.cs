namespace GameWebApi2.Mapping;

public class UserOwnedAchievementProfile : Profile
{
    public UserOwnedAchievementProfile()
    {
        CreateMaps();
    }
    private void CreateMaps()
    {
        CreateMap<UserOwnedAchievement, UserOwnedAchievementViewModel>();

        CreateMap<UserOwnedAchievementDTO, UserOwnedAchievement>();

        CreateMap<UserOwnedAchievementAddDTO, UserOwnedAchievement>();

        CreateMap<UserOwnedAchievementUpdateDTO, UserOwnedAchievement>();

    }
}
