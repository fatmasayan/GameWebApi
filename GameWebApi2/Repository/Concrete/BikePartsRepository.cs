
namespace GameWebApi2.Repository;

public class BikePartsRepository : Repository<BikeParts>, IBikePartsRepository
{
    public BikePartsRepository(DataContext context) : base(context)
    {
    }
}
