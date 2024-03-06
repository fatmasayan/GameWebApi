
namespace GameWebApi2.Repository;

public class UserCharRepository : Repository<UserChar>, IUserCharRepository
{
    public UserCharRepository(DataContext context) : base(context)
    {
    }
}
