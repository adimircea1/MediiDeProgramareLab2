using System.ComponentModel.DataAnnotations;

namespace Cremene_Mircea_Adrian_Lab2.Models;

public class Category
{
    public int Id { get; set; }
    
    [Display(Name = "Category Name")]
    public string CategoryName { get; set; } = string.Empty;
    
    public ICollection<BookCategory>? BookCategories { get; set; }
}