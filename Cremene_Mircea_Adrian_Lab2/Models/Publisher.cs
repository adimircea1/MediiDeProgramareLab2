using System.ComponentModel.DataAnnotations;

namespace Cremene_Mircea_Adrian_Lab2.Models;

public class Publisher
{
    public int Id { get; set; }
    
    [Display(Name = "Publisher Name")]
    public string PublisherName { get; set; } = string.Empty;
    
    public ICollection<Book>? Books { get; set; }
}