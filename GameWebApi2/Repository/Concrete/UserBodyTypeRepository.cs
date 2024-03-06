
namespace GameWebApi2.Repository;

public class UserBodyTypeRepository : Repository<UserBodyType>, IUserBodyTypeRepository
{
    public UserBodyTypeRepository(DataContext context) : base(context)
    {
    }
}
