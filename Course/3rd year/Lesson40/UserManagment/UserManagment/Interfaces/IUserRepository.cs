using UserManagment.Models;

public interface IUserRepository
{
    void AddUser(User user);
    void DeleteUser(int userId);
    User GetUser(int userId);
    IReadOnlyList<User> GetAllUsers();

}