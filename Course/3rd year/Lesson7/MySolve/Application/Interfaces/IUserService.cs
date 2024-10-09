namespace MySolve.Application.Interfaces;


using MySolve.Domain;


public interface IUserService
{
    Task AddUser(User user);
    Task UpdateUser(User user);
    Task DeleteUser(int id);
    Task<List<User>> GetAllUsers();

    Task<User> GetUserByEmail(string email);
}