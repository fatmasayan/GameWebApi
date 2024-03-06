namespace GameWebApi2.Repository;

public interface IRepository<TModel> where TModel : BaseEntity //TModel IEntity türünden bir nesne alacaktır.
{
    DbSet<TModel> Table { get; } // db tablosu

    // Command Operations (CRUD/ Ekleme, Silme, Güncelleme)
    bool Add(TModel model);
    bool Update(TModel model);
    bool Delete(Expression<Func<TModel, bool>> filter); //burda id alınır ve kontrol edildiği için parametre olarak bu yazılır

    // Query Operations
    List<TModel> GetAll(params Expression<Func<TModel, object>>[] includes); //tüm  
    List<TModel> GetAll(Expression<Func<TModel, bool>> filter, params Expression<Func<TModel, object>>[] includes); // özel tüm listeleme
    TModel Get(Expression<Func<TModel, bool>> filter, params Expression<Func<TModel, object>>[] includes);
    //aranan kriterde tek bir model/nesne dönecektir
    //Expression<Func<TModel, object>>? include = nul bu kısım model içinde model cagırılma oldugu için inculdem mantığı join olarka işler
}
