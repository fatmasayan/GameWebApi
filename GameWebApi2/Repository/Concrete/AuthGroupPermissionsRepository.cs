namespace GameWebApi2.Repository;

public class AuthGroupPermissionsRepository : Repository<AuthGroupPermissions>, IAuthGroupPermissionsRepository
{
    public AuthGroupPermissionsRepository(DataContext context) : base(context)
    {
    }
}
