
namespace GameWebApi2.Repository;

public class UserProfileRepository : Repository<UserProfile>, IUserProfileRepository
{
    public UserProfileRepository(DataContext context) : base(context)
    {
    }
}
