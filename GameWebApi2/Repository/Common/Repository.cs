using Microsoft.EntityFrameworkCore;

namespace GameWebApi2.Repository;
// repository içerisinde DB işlemleri yapılır. Bu sınıf haricinde db işlemi yapılmaz / kod karmaşasına neden olur esnekliği öldürür
// DB operations are done in the repository. No db operation is done outside this class / causes code complexity and kills flexibility.
public class Repository<TModel> : IRepository<TModel> where TModel : BaseEntity
{
    private readonly DataContext _context;

    public Repository(DataContext context)
    {
        _context = context;
    }

    public DbSet<TModel> Table => _context.Set<TModel>(); // ilgili tablo işlemi

    #region Command
    // Command
    public bool Add(TModel model)
    {
        try
        {
            var result = EntityState.Added == Table.Add(model).State; //işlemin insert olup olmadığını kontrol etmek geriye döndürerek ve bir değişkene atama
                                                                      //check if the operation is insert by returning and assigning to a variable

            _context.SaveChanges(); //fonksiyonu tanımladığım yerde her seferinde ilglili değişlikliği kaydetme işlemi yapmamak için burda yapılır
                                    //where I define the function, it is done here to avoid saving the relevant change each time.
            return result;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.InnerException);

            return false;// herhangi bir hata olursa yada başarısız işlem olursa false dönmesi için try-catch kullanılır
                         // use try-catch to return false in case of any error or failed operation
        }
    }

    public bool Delete(Expression<Func<TModel, bool>> filter)
    {
        try
        {
            var model = Table.FirstOrDefault(filter);
            var result = EntityState.Deleted == Table.Remove(model).State;
            // delete/silme işleminin başarılı olup olmadığını kontrol etmek geriye döndürerek ve bir değişkene atama
            // check if the deletion was successful by returning and assigning to a variable
            _context.SaveChanges();

            return result;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.InnerException);

            return false;
        }
    }

    public bool Update(TModel model)
    {
        try
        {
            var result = EntityState.Modified == Table.Update(model).State;
            //güncelleme işleminin başarılı  olup olmadığını kontrol etmek geriye döndürerek ve bir değişkene atama
            // check if the update operation was successful by returning and assigning to a variable
            _context.SaveChanges();

            return result;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.InnerException);

            return false;
        }
    }
    #endregion

    #region Query
    // Query
    public TModel Get(Expression<Func<TModel, bool>> filter, params Expression<Func<TModel, object>>[] includes)//params ile istediğimiz sayıda expression ifade almamıza imkan tanıdı
    {                                                                                                           // allowed us to get any number of expressions with params

        try //Asnotracking -- modeli hiçbir şekilde takip etmemeli performans  düşürücü bir eylem ve takip edilen model değiştirebilir. Bunu engellemek için kullanıyoruz
        {   // Asnotracking -- the model should not be tracked in any way, it is a performance degrading action and may change the model being tracked. To prevent this we use
            var query = Table.AsNoTracking().Where(filter);

            //inner join işlemi yapıldı 
            foreach (var include in includes) // was inculde each one
                query = query.Include(include);

            return query.FirstOrDefault(); // returning the value with the found

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.InnerException);

            return null;
        }
    }

    public List<TModel> GetAll(params Expression<Func<TModel, object>>[] includes) // model to list everything
    { 
        try
        {
            var query = Table.AsNoTracking();

            foreach (var include in includes)
                query = query.Include(include);

            return query.ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.InnerException);

            return null;
        }
    }

    public List<TModel> GetAll(Expression<Func<TModel, bool>> filter, params Expression<Func<TModel, object>>[] includes)
    { // create the list according to the desired content - filtered listing
        try
        {
            var query = Table.AsNoTracking().Where(filter);

            foreach (var include in includes)
                query = query.Include(include);

            return query.ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.InnerException);

            return null;
        }
    }
    #endregion

}
