
namespace GameWebApi2.Repository;

public class AuthUserGroupsRepository : Repository<AuthUserGroups>, IAuthUserGroupsRepository
{
    public AuthUserGroupsRepository(DataContext context) : base(context)
    {
    }
}
