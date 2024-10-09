using MySolve.Domain;
using MySolve.Application.Interfaces;
using MySolve.Application.Contexts;
using Microsoft.EntityFrameworkCore;

namespace MySolve.Infrastructure.Repositories;

public class BookRepository : IBookRepository
{
    private readonly LibraryContext _libraryContext;

    public BookRepository(LibraryContext libraryContext)
    {
        _libraryContext = libraryContext;
    }
    public async Task Add(Book book)
    {
        await _libraryContext.Books.AddAsync(book);
        await _libraryContext.SaveChangesAsync();
    }

    public async Task Update(Book book)
    {
        var existingBook = _libraryContext.Books.FirstOrDefault(b => b.Id == book.Id);
        if (existingBook != null)
        {
            _libraryContext.Books.Update(book);
            await _libraryContext.SaveChangesAsync();
        }
        
    }

    public async Task Delete(int id)
    {
        var book = _libraryContext.Books.FirstOrDefault(b => b.Id == id);
        if (book != null)
        {
            _libraryContext.Books.Remove(book);

            await _libraryContext.SaveChangesAsync();
        }
    }

    public async Task<List<Book>> GetAll()
    {
        return await _libraryContext.Books.ToListAsync();
    }

    public async Task<Book> GetByName(string name)
    {
        return await _libraryContext.Books.FirstOrDefaultAsync(b => b.Name == name);
    }
}