
namespace GameWebApi2.Repository;

public class CharItemsRepository : Repository<CharItems>, ICharItemsRepository
{
    public CharItemsRepository(DataContext context) : base(context)
    {
    }
}
