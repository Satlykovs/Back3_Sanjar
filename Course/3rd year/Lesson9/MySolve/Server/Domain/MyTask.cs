
using System.ComponentModel.DataAnnotations;


public class MyTask
{
    public int Id { get; set; }
    [Required]
    [MinLength(3)]
    public string Title { get; set; }
    public DateTime dateTime{ get; set; }
    [Required]
    [MinLength(3)]
    public string Author { get; set; }
}