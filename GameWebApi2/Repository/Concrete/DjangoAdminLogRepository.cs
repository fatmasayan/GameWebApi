
namespace GameWebApi2.Repository;

public class DjangoAdminLogRepository : Repository<DjangoAdminLog>, IDjangoAdminLogRepository
{
    public DjangoAdminLogRepository(DataContext context) : base(context)
    {
    }
}
