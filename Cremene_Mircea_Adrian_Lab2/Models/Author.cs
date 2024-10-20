using System.ComponentModel.DataAnnotations;

namespace Cremene_Mircea_Adrian_Lab2.Models;

public class Author
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    [Display(Name = "Author Name")]
    public string AuthorName => FirstName + " " + LastName;
    
    public ICollection<Book>? Books { get; set; }
}