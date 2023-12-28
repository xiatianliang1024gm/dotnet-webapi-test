using webapi_test.Entity;

namespace webapi_test.Data;

using Microsoft.EntityFrameworkCore;

public class Repository<T, TKey> : IRepository<T, TKey>
    where TKey : IEquatable<TKey>
    // add class to suppress DbSet<T> check, The type 'T' must be a reference type in order to use it as parameter
    where T : class, IEntity<TKey>
{
    protected readonly IdentifierContext _context;
    protected readonly DbSet<T> _dataSet;

    // primary constructor means all attributes, fields list in params
    // add DbSet<T> dataSet
    public Repository(IdentifierContext context)
    {
        _context = context;
        _dataSet = context.Set<T>();
    }

    public IEnumerable<T> GetAll()
    {
        return _dataSet.ToList();
    }

    public T? GetById(TKey id)
    {
        return _dataSet.Where(p => p.Id.Equals(id)).FirstOrDefault();
    }

    public void Create(T entity)
    {
        _dataSet.Add(entity);
    }

    public void Update(T entity)
    {
        _dataSet.Update(entity);
    }

    public void Delete(TKey id)
    {
        var one = GetById(id);
        if (one == null)
        {
            return;
        }

        _dataSet.Remove(one);
    }

    public int SaveChanges()
    {
        return _context.SaveChanges();
    }
}