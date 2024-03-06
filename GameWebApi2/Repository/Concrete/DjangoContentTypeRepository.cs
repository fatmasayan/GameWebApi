
namespace GameWebApi2.Repository;

public class DjangoContentTypeRepository : Repository<DjangoContentType>, IDjangoContentTypeRepository
{
    public DjangoContentTypeRepository(DataContext context) : base(context)
    {
    }
}
