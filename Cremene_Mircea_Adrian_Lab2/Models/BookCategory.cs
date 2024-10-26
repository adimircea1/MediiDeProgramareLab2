namespace Cremene_Mircea_Adrian_Lab2.Models;

public class BookCategory
{
    public int Id { get; set; }
    public int BookId { get; set; }
    public int CategoryId { get; set; }
    public Book? Book { get; set; }
    public Category? Category { get; set; }
}