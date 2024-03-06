
namespace GameWebApi2.Repository;

public class UserBikesRepository : Repository<UserBikes>, IUserBikesRepository
{
    public UserBikesRepository(DataContext context) : base(context)
    {
    }
}
