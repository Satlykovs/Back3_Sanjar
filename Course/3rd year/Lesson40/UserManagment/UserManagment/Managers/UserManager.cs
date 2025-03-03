using UserManagment.Models;
using UserManagment.Interfaces;

namespace UserManagment.Managers;

public class UserManager : IUserManager
{
    private readonly IUserRepository _userRepository;
    private readonly IEmailManager _emailManager;

    public UserManager(IEmailManager emailManager, IUserRepository userRepository)
    {
        _emailManager  = emailManager;
        _userRepository = userRepository;
    }

    public void AddUser(UserCreateDTO userData)
    {
        
        _userRepository.AddUser(new User {Username = userData.Username, Email = userData.Email});
        _emailManager.SendWelcomeEmail(userData.Email);
    }

    public void DeleteUser(int userId)
    {
        _userRepository.DeleteUser(userId);
    }

    public User GetUser(int userId)
    {
        return _userRepository.GetUser(userId);
    }

    public IEnumerable<User> GetAllUsers()
    {
        return _userRepository.GetAllUsers();
    }


}
