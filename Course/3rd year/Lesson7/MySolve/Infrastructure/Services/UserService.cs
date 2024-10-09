using MySolve.Domain;
using MySolve.Application.Interfaces;

namespace MySolve.Infrastructure.Services;
public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task AddUser(User user)
    {
        await _userRepository.Add(user);
    }

    public async Task UpdateUser(User user)
    {
        await _userRepository.Update(user);
    }

    public async Task DeleteUser(int id)
    {
        await _userRepository.Delete(id);
    }

    public async Task<List<User>> GetAllUsers()
    {
        return await _userRepository.GetAll();
    }

    public async Task<User> GetUserByEmail(string email)
    {
        return await _userRepository.GetByEmail(email);
    }
}

