using Microsoft.EntityFrameworkCore;
using webapi_test.Models;

namespace webapi_test.Data;

interface INormalBookRepository
{
    public IEnumerable<Book> GetAll();

    public Book? GetById(int id);

    public void Create(Book book);

    public void Update(Book book);

    public void Delete(int id);

    public int SaveChanges();
}

class NormalBookRepository : INormalBookRepository
{
    private readonly IdentifierContext _context;
    private readonly DbSet<Book> _dbSet;

    public NormalBookRepository(IdentifierContext context)
    {
        _context = context;
        _dbSet = context.Set<Book>();
    }

    public IEnumerable<Book> GetAll()
    {
        return _dbSet.ToList();
    }

    public Book? GetById(int id)
    {
        // First will throw exception is no element match query condition
        // default(T) is T is nullable, return null, otherwise return zero value
        return _dbSet.FirstOrDefault(p => p.Id == id);
    }

    public void Create(Book book)
    {
        _dbSet.Add(book);
    }

    public void Update(Book book)
    {
        _dbSet.Update(book);
    }

    public void Delete(int id)
    {
        var one = GetById(id);
        if (one == null)
        {
            return;
        }

        _dbSet.Remove(one);
    }

    public int SaveChanges()
    {
        return _context.SaveChanges();
    }
}