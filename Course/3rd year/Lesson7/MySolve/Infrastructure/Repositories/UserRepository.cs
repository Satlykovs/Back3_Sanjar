
using MySolve.Domain;
using MySolve.Application.Interfaces;
using MySolve.Application.Contexts;
using Microsoft.EntityFrameworkCore;

namespace MySolve.Infrastructure.Repositories;
public class UserRepository : IUserRepository
{
    private readonly UserContext _userContext;

    public UserRepository(UserContext userContext)
    {
        _userContext = userContext;
    }

    public async Task Add(User user)
    {
        await _userContext.Users.AddAsync(user);
        await _userContext.SaveChangesAsync();
    }

    public async Task Update(User user)
    {
        var existingUser = _userContext.Users.FirstOrDefault(u => u.Id == user.Id);
        if (existingUser != null)
        {
            _userContext.Users.Update(user);
        }
        await _userContext.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var user = await _userContext.Users.FindAsync(id);
        if (user != null)
        {
            _userContext.Users.Remove(user);

            await _userContext.SaveChangesAsync();
        }
    }

    public async Task<List<User>> GetAll()
    {
        return await _userContext.Users.ToListAsync();
    }

    public async Task<User> GetByEmail(string email)
    {
        return await _userContext.Users.FirstOrDefaultAsync(u => u.Email == email);
    }
}
