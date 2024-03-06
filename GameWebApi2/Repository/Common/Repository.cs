using Microsoft.EntityFrameworkCore;

namespace GameWebApi2.Repository;
// repository içerisinde DB işlemleri yapılır. Bu sınıf haricinde db işlemi yapılmaz / kod karmaşasına neden olur esnekliği öldürür
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

            _context.SaveChanges(); //fonksiyonu tanımladığım yerde her seferinde ilglili değişlikliği kaydetme işlemi yapmamak için burda yapılır

            return result;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.InnerException);

            return false;// herhangi bir hata olursa yada başarısız işlem olursa false dönmesi için try-catch kullanılır
        }
    }

    public bool Delete(Expression<Func<TModel, bool>> filter)
    {
        try
        {
            var model = Table.FirstOrDefault(filter);
            var result = EntityState.Deleted == Table.Remove(model).State;
            // delete/silme işleminin başarılı olup olmadığını kontrol etmek geriye döndürerek ve bir değişkene atama
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
    {
        try //Asnotracking -- modeli hiçbir şekilde takip etmemeli performans  düşürücü bir eylem ve takip edilen model değiştirebilir. Bunu engellemek için kullanıyoruz
        {
            var query = Table.AsNoTracking().Where(filter);

            //inner join işlemi yapıldı 
            foreach (var include in includes) //her birini inculde ettik
                query = query.Include(include);

            return query.FirstOrDefault(); // bulunan ile değeri döndürme işlemi yapıyoruz
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.InnerException);

            return null;
        }
    }

    public List<TModel> GetAll(params Expression<Func<TModel, object>>[] includes)
    { //her şeyi listelemek için oluşturlan model
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
    { // istenilen şeyi içerenleri listeleme - filtreli listeleme
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
