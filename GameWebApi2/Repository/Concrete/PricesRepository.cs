
namespace GameWebApi2.Repository;

public class PricesRepository : Repository<Prices>, IPricesRepository
{
    public PricesRepository(DataContext context) : base(context)
    {
    }
}
