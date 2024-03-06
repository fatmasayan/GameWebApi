
namespace GameWebApi2.Repository;

public class DjangoSessionRepository : Repository<DjangoSession>, IDjangoSessionRepository
{
    public DjangoSessionRepository(DataContext context) : base(context)
    {
    }
}
