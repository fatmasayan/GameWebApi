
namespace GameWebApi2.Repository;

public class AuthUserRepository : Repository<AuthUser>, IAuthUserRepository
{
    public AuthUserRepository(DataContext context) : base(context)
    {
    }
}
