
using System.ComponentModel.DataAnnotations;


public class MyTask
{
    public int Id { get; set; }
    [Required]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Title name must be from 3 to 100 characters.")]
    public string Title { get; set; }
    public DateTime dateTime{ get; set; }
    [Required]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Author name must be from 3 to 100 characters.")]
    public string Author { get; set; }
}