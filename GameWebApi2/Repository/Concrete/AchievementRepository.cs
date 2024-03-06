namespace GameWebApi2.Repository;

public class AchievementRepository : Repository<Achievement>, IAchievementRepository
{
    public AchievementRepository(DataContext context) : base(context)
    {
    }
}
