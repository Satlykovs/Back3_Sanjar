namespace MySolve.Application.Interfaces;

using MySolve.Domain;

public interface IBookRepository
{
    Task Add(Book book);
    Task Update(Book book);
    Task Delete(int id);
    Task<List<Book>> GetAll();

    Task<Book> GetByName(string name);

    
}
