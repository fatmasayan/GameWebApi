
namespace GameWebApi2.Repository;

public class UserOwendMapRepository : Repository<UserOwendMap>, IUserOwendMapRepository
{
    public UserOwendMapRepository(DataContext context) : base(context)
    {
    }
}
