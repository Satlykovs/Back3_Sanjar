using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using SecureApi.Models;

namespace SecureApi.Managers;


class JwtManager : IJwtManager
{
    private readonly IConfiguration _config;

    public JwtManager(IConfiguration config) => _config = config;

    public string GenerateJwtToken(User user)
    {
        var claims = new List<Claim>
        {
            new (ClaimTypes.Email, user.Email),
            new (ClaimTypes.Role, user.Role)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:SecretKey"]));

        var credentials  = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"],
            audience: _config["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials:credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}