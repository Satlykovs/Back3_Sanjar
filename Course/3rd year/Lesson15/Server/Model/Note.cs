using System.ComponentModel.DataAnnotations;

public class Note
{
    public int Id {get; set;}

    [Required]
    [MinLength(2)]
    public string Title {get; set;}

    [Required]
    [MinLength(2)]
    public string Content {get; set;}
}