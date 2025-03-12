using System.Reflection.Metadata.Ecma335;

namespace SecureApi.Controllers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SecureApi.Managers;
using SecureApi.Models;

[ApiController]
[Route("api/[controller]")]

// Извините, да, знаю, нарушаю паттерны, но просто очень долго всё это писать, а суть задания в написании мидлвары ratelimitng
// Надеюсь, простительно, если нет, переделаю
public class AuthController : ControllerBase
{

    private readonly IJwtManager _jwtManager;
    public AuthController(IJwtManager jwtManager) => _jwtManager = jwtManager; 

    [HttpPost("login")]
    public IActionResult Login([FromBody] UserLoginDto dto)
    {
        if (!ModelState.IsValid)
        {
            return ValidationProblem(ModelState);
        }

        if (dto.Email != "email@email.com" || dto.Password != "password")
        {
            return Unauthorized();
        }

        var token = _jwtManager.GenerateJwtToken(new User{Email = dto.Email, Password = dto.Password, Role = "Admin"});

        return Ok(token);

        
    }

    [Authorize]
    [HttpGet("data")]
    public IActionResult SuperMegaHyperSecuredData() => Ok("Ты сейчас смотришь в монитор");

    [Authorize(Roles = "Admin")]
    [HttpGet("admin-data")]
    public IActionResult AdminMegaSecuredDataPlsDontCallThisFunc() => Ok("https://www.youtube.com/watch?v=dQw4w9WgXcQ");
}