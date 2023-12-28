using Microsoft.AspNetCore.Mvc;
using webapi_test.Entity;
using webapi_test.Models;
using webapi_test.Services;

namespace webapi_test.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class BookController : ControllerBase
{
    private readonly BookService _bookService;

    public BookController(BookService bookService)
    {
        _bookService = bookService;
    }

    // if use /GetAll, will override /api/[controller] prefix
    [HttpPost]
    [Route("GetAll")]
    public IEnumerable<Book> GetAll()
    {
        return _bookService.GetAll();
    }

    [HttpPost]
    [Route("GetById")]
    public Book? GetById(int id)
    {
        return _bookService.GetById(id);
    }

    [HttpPost]
    [Route("GetByPage")]
    public PaginationResult<Book> GetByPage(int pageSize, int pageNum)
    {
        return _bookService.GetByPage(pageSize, pageNum);
    }


    [HttpPost]
    [Route("Create")]
    public void Create(Book book)
    {
        _bookService.Create(book);
    }

    [HttpPost]
    [Route("Update")]
    public void Update(Book book)
    {
        _bookService.Update(book);
    }

    [HttpPost]
    [Route("Delete")]
    public void Delete(int bookId)
    {
        _bookService.Delete(bookId);
    }
}