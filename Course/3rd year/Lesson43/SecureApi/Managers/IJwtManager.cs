using SecureApi.Models;

namespace SecureApi.Managers;

public interface IJwtManager
{
    string GenerateJwtToken(User user);
}