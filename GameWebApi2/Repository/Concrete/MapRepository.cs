
namespace GameWebApi2.Repository;

public class MapRepository : Repository<Map>, IMapRepository
{
    public MapRepository(DataContext context) : base(context)
    {
    }
}
