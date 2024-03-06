
namespace GameWebApi2.Repository;

public class AuthUserAndUserPermissionsRepository : Repository<AuthUserAndUserPermissions>, IAuthUserAndUserPermissionsRepository

{
    public AuthUserAndUserPermissionsRepository(DataContext context) : base(context)
    {
    }
}
