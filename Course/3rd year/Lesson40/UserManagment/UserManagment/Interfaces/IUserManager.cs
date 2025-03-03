using UserManagment.Models;

namespace UserManagment.Interfaces;

public interface IUserManager
{
    public void AddUser(UserCreateDTO userData);
    public void DeleteUser(int userId);
    public User GetUser(int userId);
    public IEnumerable<User> GetAllUsers();



}