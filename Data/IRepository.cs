namespace webapi_test.Data;

using webapi_test.Entity;

public interface IRepository<T, TKey>
// the contract between T, and Key should be express by IEntity, IRepository<IEntity<TKey>, TKey> not work
    where T : IEntity<TKey>
    // indicate that TKey could be used in ==, Equals
    where TKey : IEquatable<TKey>
{
    public IEnumerable<T> GetAll();

    public T? GetById(TKey id);

    public void Create(T entity);

    public void Update(T entity);

    public void Delete(TKey id);

    public int SaveChanges();
}