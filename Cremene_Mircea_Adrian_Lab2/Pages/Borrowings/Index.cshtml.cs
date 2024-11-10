using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Cremene_Mircea_Adrian_Lab2.Models;

namespace Cremene_Mircea_Adrian_Lab2.Pages.Borrowings
{
    public class IndexModel : PageModel
    {
        private readonly Data.Cremene_Mircea_Adrian_Lab2Context _context;

        public IndexModel(Data.Cremene_Mircea_Adrian_Lab2Context context)
        {
            _context = context;
        }

        public IList<Borrowing> Borrowing { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Borrowing = await _context.Borrowing
                .Include(b => b.Book)
                .ThenInclude(b => b!.Author)
                .Include(b => b.Member).ToListAsync();
        }
    }
}
