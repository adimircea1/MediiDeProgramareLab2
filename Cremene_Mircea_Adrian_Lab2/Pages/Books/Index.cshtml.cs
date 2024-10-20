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

        public async Task OnGetAsync()
        {
            Book = await _context.Book
                .Include(b=>b.Publisher)
                .Include(b => b.Author)
                .ToListAsync();
        }
    }
}
