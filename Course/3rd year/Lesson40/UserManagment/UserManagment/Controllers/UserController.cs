using Microsoft.AspNetCore.Mvc;
using UserManagment.Interfaces;
using UserManagment.Managers;
using UserManagment.Models;

namespace UserManagment.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserManager _userManager;

    public UserController(IUserManager userManager)
    {
        _userManager = userManager;
    }

    [HttpPost("CreateUser")]
    public IActionResult CreateUser([FromBody] UserCreateDTO userData)
    {
        if (!ModelState.IsValid)
        {
            return ValidationProblem(ModelState);
        }
        _userManager.AddUser(userData);
        return Ok($"User {userData.Email} added");
    }

    [HttpDelete("RemoveUser")]
    public IActionResult RemoveUser(int userId)
    {
        _userManager.DeleteUser(userId);
        return Ok($"User with ID {userId} removed.");
    }

    [HttpGet("ShowUser")]
    public IActionResult ShowUser(int userId)
    {
        var user = _userManager.GetUser(userId);
        if (user != null)
        {
            return Ok($"User: {user.Username}, Email: {user.Email}");
        }
        else
        {
            return Ok("User not found.");
        }
    }

    [HttpGet("ListUsers")]
    public IActionResult ListUsers()
    {
        var users = _userManager.GetAllUsers();
        return Ok(users);
    }
}
