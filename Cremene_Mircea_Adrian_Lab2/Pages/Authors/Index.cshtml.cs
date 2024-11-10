using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Cremene_Mircea_Adrian_Lab2.Models;

namespace Cremene_Mircea_Adrian_Lab2.Pages.Authors
{
    public class IndexModel : PageModel
    {
        private readonly Data.Cremene_Mircea_Adrian_Lab2Context _context;

        public IndexModel(Data.Cremene_Mircea_Adrian_Lab2Context context)
        {
            _context = context;
        }

        public IList<Author> Author { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Author = await _context.Author.ToListAsync();
        }
    }
}
