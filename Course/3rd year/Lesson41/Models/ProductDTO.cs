using System.ComponentModel.DataAnnotations;

namespace ProductAPI.Models;


public class ProductDTO
{
    [Required(ErrorMessage = "Name field is required")]
    [StringLength(100, ErrorMessage = "Wrong name size")]
    public string Name {get; set; }

    [Range(0.01, 10000, ErrorMessage = "Price is out of range")]
    public decimal Price  {get; set; }

    [Required(ErrorMessage = "Category field is required")]
    [StringLength(50, ErrorMessage = "Wrong category size")]
    public string Category { get; set; }
}