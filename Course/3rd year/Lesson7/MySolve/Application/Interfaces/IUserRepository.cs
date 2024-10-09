namespace MySolve.Application.Interfaces;

using MySolve.Domain;

public interface IUserRepository
{
    Task Add(User book);
    Task Update(User book);
    Task Delete(int id);
    Task<List<User>> GetAll();

    Task<User> GetByEmail(string email);
}
