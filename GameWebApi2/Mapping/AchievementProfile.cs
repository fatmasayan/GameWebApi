namespace GameWebApi2.Mapping
{
    public class AchievementProfile :Profile
    {
        public AchievementProfile()
        {
            CreateMaps();
        }

        private void CreateMaps()
        {
            CreateMap<Achievement, AchievementViewModel>();
            CreateMap<AchievementDTO, Achievement>();

            CreateMap<AchievementAddDTO, Achievement>();

            CreateMap<AchievementUpdateDTO, Achievement>();
        }

    }
}
