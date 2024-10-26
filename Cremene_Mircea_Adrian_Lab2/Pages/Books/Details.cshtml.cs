using Cremene_Mircea_Adrian_Lab2.Data;
using Cremene_Mircea_Adrian_Lab2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Cremene_Mircea_Adrian_Lab2.Pages.Books
{
    public class DetailsModel : PageModel
    {
        private readonly Cremene_Mircea_Adrian_Lab2Context _context;

        public DetailsModel(Cremene_Mircea_Adrian_Lab2Context context)
        {
            _context = context;
        }

        public Book Book { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .Include(b => b.BookCategories)!
                .ThenInclude(b => b.Category)
                .AsNoTracking()
                .OrderBy(b => b.Title)
                .FirstOrDefaultAsync(b => b.Id == id);
            
            if (book == null)
            {
                return NotFound();
            }

            Book = book;
            return Page();
        }
    }
}
