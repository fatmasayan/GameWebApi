namespace GameWebApi2.Repository;

public class AuthGroupRepository : Repository<AuthGroup>, IAuthGroupRepository
{
    public AuthGroupRepository(DataContext context) : base(context)
    {
    }
}
