namespace MySolve.Application.Interfaces;


using MySolve.Domain;

public interface IBookService
{
    Task AddBook(Book book);
    Task UpdateBook(Book book);
    Task DeleteBook(int id);
    Task<List<Book>> GetAllBooks();

    Task<Book> GetBookByName(string name);

}