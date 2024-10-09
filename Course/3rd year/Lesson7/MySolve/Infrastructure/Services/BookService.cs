using MySolve.Domain;
using MySolve.Application.Interfaces;

namespace MySolve.Infrastructure.Services;
public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;

    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task AddBook(Book book)
    {
        await _bookRepository.Add(book);
    }

    public async Task UpdateBook(Book book)
    {
        await _bookRepository.Update(book);
    }

    public async Task DeleteBook(int id)
    {
        await _bookRepository.Delete(id);
    }

    public async Task<List<Book>> GetAllBooks()
    {
        return  await _bookRepository.GetAll();
    }

    public async Task<Book> GetBookByName(string name)
    {
       return await _bookRepository.GetByName(name);
    }
}

