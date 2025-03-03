using System.Collections.Generic;
using UserManagment.Models;
using UserManagment.Interfaces;

namespace UserManagment.Repositories;

public class InMemoryUserRepository : IUserRepository
{
    private static readonly List<User> users = new List<User>();
    private static int lastIndex = 0;

    public void AddUser(User user)
    {
        user.Id = ++lastIndex;
        users.Add(user);
    }

    public void DeleteUser(int userId)
    {
        var user = users.FirstOrDefault(u => u.Id == userId);
        if (userId == lastIndex) lastIndex--;
        if (user != null) users.Remove(user);
    }

    public User GetUser(int userId)
    {
        return users.FirstOrDefault(u => u.Id == userId);
    }

    public IReadOnlyList<User> GetAllUsers()
    {
        return users.AsReadOnly();
    }
    

}