
namespace GameWebApi2.Repository;

public class PurchaseRepository : Repository<Purchase>, IPurchaseRepository
{
    public PurchaseRepository(DataContext context) : base(context)
    {
    }
}
