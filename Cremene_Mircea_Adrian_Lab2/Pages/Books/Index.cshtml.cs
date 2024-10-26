using Cremene_Mircea_Adrian_Lab2.Data;
using Cremene_Mircea_Adrian_Lab2.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Cremene_Mircea_Adrian_Lab2.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly Cremene_Mircea_Adrian_Lab2Context _context;

        public IndexModel(Cremene_Mircea_Adrian_Lab2Context context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; } = default!;
        public BookData BookD { get; set; }
        public int BookId { get; set; }
        public int CategoryId { get; set; }
        
        public async Task OnGetAsync(int? id, int? categoryId)
        {
            BookD = new BookData();

            BookD.Books = await _context.Book
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .Include(b => b.BookCategories)!
                .ThenInclude(b => b.Category)
                .AsNoTracking()
                .OrderBy(b => b.Title)
                .ToListAsync();

            if (id is not null)
            {
                BookId = id.Value;
                Book book = BookD.Books.Single(i => i.Id == id.Value);
                BookD.Categories = book.BookCategories!.Select(s => s.Category)!;
            }
        }
    }
}
