
namespace GameWebApi2.Repository;

public class DjangoMigrationsRepository : Repository<DjangoMigrations>, IDjangoMigrationsRepository
{
    public DjangoMigrationsRepository(DataContext context) : base(context)
    {
    }
}
