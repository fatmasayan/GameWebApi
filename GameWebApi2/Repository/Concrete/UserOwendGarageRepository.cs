
namespace GameWebApi2.Repository;

public class UserOwendGarageRepository : Repository<UserOwendGarage>, IUserOwendGarageRepository
{
    public UserOwendGarageRepository(DataContext context) : base(context)
    {
    }
}
