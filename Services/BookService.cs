using webapi_test.Data;
using webapi_test.Entity;
using webapi_test.Models;

namespace webapi_test.Services;

public class BookService
{
    private readonly BookRepository _bookRepository;

    public BookService(BookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public IEnumerable<Book> GetAll()
    {
        return _bookRepository.GetAll();
    }

    public Book? GetById(int id)
    {
        return _bookRepository.GetById(id);
    }

    public PaginationResult<Book> GetByPage(int pageSize, int pageNum)
    {
        return _bookRepository.GetByPage(pageNum, pageSize);
    }

    public void Create(Book book)
    {
        _bookRepository.Create(book);
        _bookRepository.SaveChanges();
    }

    public void Update(Book book)
    {
        _bookRepository.Update(book);
        _bookRepository.SaveChanges();
    }

    public void Delete(int bookId)
    {
        _bookRepository.Delete(bookId);
        _bookRepository.SaveChanges();
    }
}