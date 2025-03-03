namespace UserManagment.Models;

using System.ComponentModel.DataAnnotations;

public class UserCreateDTO
{
    [Required(ErrorMessage = "Username field is required")]
    [MinLength(3, ErrorMessage =  "Username field must be at least 3 chars long")]
    public string Username { get; set; }

    [Required(ErrorMessage = "Email field is required")]
    [RegularExpression("^\\S+@\\S+\\.\\S+$", ErrorMessage = "Invalid email format")]
    public string Email { get; set; }

}