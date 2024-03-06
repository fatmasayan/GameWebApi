
namespace GameWebApi2.Repository;

public class AuthPermissionRepository : Repository<AuthPermission>, IAuthPermissionRepository
{
    public AuthPermissionRepository(DataContext context) : base(context)
    {
    }
}
