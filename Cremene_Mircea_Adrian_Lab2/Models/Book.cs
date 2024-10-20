using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cremene_Mircea_Adrian_Lab2.Models;

public class Book
{
    public int Id { get; set; }
    
    [Display(Name = "Book Title")]
    public string Title { get; set; } = string.Empty;
    
    [Column(TypeName = "decimal(6,2)")]
    public decimal Price { get; set; }
    
    [DataType(DataType.Date)]
    public DateTime PublishingDate { get; set; }
    
    public int? PublisherId { get; set; }
    public int? AuthorId { get; set; }
    public Author? Author { get; set; }
    public Publisher? Publisher { get; set; } 
}