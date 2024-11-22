using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Order
{

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    

    public Customer Customer { get; set; }
    
    public List<Product> Products { get; set; } = new List<Product>();
}