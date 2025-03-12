using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SecureApi.Models;


public class User
{

    public string Email { get; set; }
    
    
    public string Password { get; set; }
    public string Role { get; set; }
}