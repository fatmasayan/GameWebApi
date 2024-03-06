
namespace GameWebApi2.Repository;

public class AuthtokenTokenRepository : Repository<AuthtokenToken>, IAuthtokenTokenRepository
{
    public AuthtokenTokenRepository(DataContext context) : base(context)
    {
    }
}
