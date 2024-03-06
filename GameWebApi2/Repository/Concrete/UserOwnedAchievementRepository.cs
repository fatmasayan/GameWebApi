
namespace GameWebApi2.Repository;

public class UserOwnedAchievementRepository : Repository<UserOwnedAchievement>, IUserOwnedAchievementRepository
{
    public UserOwnedAchievementRepository(DataContext context) : base(context)
    {
    }
}
