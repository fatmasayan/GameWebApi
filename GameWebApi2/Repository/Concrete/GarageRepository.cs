namespace GameWebApi2.Repository;

public class GarageRepository : Repository<Garage>, IGarageRepository
{
    public GarageRepository(DataContext context) : base(context)
    {
    }
}
