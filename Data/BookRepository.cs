using Microsoft.EntityFrameworkCore;
using webapi_test.Entity;
using webapi_test.Models;

namespace webapi_test.Data;

// use interface for mock/test
public interface IBookRepository : IRepository<Book, int>
{
    public PaginationResult<Book> GetByPage(int pageNum, int pageSize);
}

// use type parameter <Book, int> to tell the compile how BookRepository work
public class BookRepository : Repository<Book, int>, IBookRepository
{
    // base(params) 
    public BookRepository(IdentifierContext context) : base(context)
    {
    }

    public PaginationResult<Book> GetByPage(int pageNum, int pageSize)
    {
        var query = _dataSet.AsQueryable().AsNoTracking();
        var res = new PaginationResult<Book>();

        res.Total = query.Count();

        if (res.Total < (pageNum - 1) * pageSize)
        {
            return res;
        }

        var list = query
            .OrderByDescending(p => p.Id)
            .Skip((pageNum - 1) * pageSize)
            .Take(pageSize)
            .ToList();
        res.List = list;
        return res;
    }
}