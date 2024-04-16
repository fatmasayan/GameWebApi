namespace GameWebApi2.Repository;

public interface IRepository<TModel> where TModel : BaseEntity //TModel IEntity türünden bir nesne alacaktır.
{
    DbSet<TModel> Table { get; } // db tablosu

    // Command Operations (CRUD/Create, Remove, Update, Delete)
    bool Add(TModel model);
    bool Update(TModel model);
    bool Delete(Expression<Func<TModel, bool>> filter); // here id is taken and this is written as a parameter because it is checked

    // Query Operations
    List<TModel> GetAll(params Expression<Func<TModel, object>>[] includes); //all
    List<TModel> GetAll(Expression<Func<TModel, bool>> filter, params Expression<Func<TModel, object>>[] includes); // custom all listing
    TModel Get(Expression<Func<TModel, bool>> filter, params Expression<Func<TModel, object>>[] includes);
    // will return a single model/object with the searched criteria.
    // (Expression<Func<TModel, object>>? include = null ) since this part is a model call within a model, the include logic works as a join
}
