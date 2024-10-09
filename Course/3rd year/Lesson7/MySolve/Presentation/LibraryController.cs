using MySolve.Application.Interfaces;
using MySolve.Domain;

using Microsoft.AspNetCore.Mvc;

namespace MySolve.Controllers.LibraryController;


[Route("libapi")]
public class LibraryController : ControllerBase
{
    private IBookService _bookService;

    public LibraryController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_bookService.GetAllBooks());
    }

    [HttpGet("{name}")]
    public async Task<IActionResult> GetBookByName(string name)
    {
        Book book = await _bookService.GetBookByName(name);

        if (book != null)
        {
            return Ok(book);
        }
        return NotFound("no such books");
    }

    [HttpPost()]
    public async Task<IActionResult> AddBook([FromBody] Book book)
    {
        await _bookService.AddBook(book);
        return Ok();
    }    

    [HttpPost("update")]
    public async Task<IActionResult> UpdateBook([FromBody] Book book)
    {
        await _bookService.UpdateBook(book);
        return Ok();
    }
}