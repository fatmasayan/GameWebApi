
namespace GameWebApi2.Repository;

public class UserInventoryRepository : Repository<UserInventory>, IUserInventoryRepository
{
    public UserInventoryRepository(DataContext context) : base(context)
    {
    }
}
