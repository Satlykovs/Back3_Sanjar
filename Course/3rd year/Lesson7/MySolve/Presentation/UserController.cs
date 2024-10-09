using MySolve.Application.Interfaces;
using MySolve.Domain;

using Microsoft.AspNetCore.Mvc;

namespace MySolve.Controllers.LibraryController;


[Route("userapi")]
public class UserController : ControllerBase
{
    private IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_userService.GetAllUsers());
    }

    [HttpGet("{email}")]
    public async Task<IActionResult> GetUserByName(string email)
    {
        User user = await _userService.GetUserByEmail(email);

        if (user != null)
        {
            return Ok(user);
        }
        return NotFound("no such user");
    }

    [HttpPost("update")]
    public async Task<IActionResult> UpdateUser([FromBody] User user)
    {
        await _userService.UpdateUser(user);
        return Ok(user);
    }

    [HttpPost()]
    public async Task<IActionResult> AddUser([FromBody] User user)
    {
        await _userService.AddUser(user);
        return Ok();
    }
    
}