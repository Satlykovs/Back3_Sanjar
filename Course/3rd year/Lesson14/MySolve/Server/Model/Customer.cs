using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata;

public class Customer
{   
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    [StringLength(100, MinimumLength = 5)]
    public string Name { get; set; }
    [Required]
    [EmailAddress(ErrorMessage = "Неправильный формат почты.")]
    public string Email { get; set; }

}