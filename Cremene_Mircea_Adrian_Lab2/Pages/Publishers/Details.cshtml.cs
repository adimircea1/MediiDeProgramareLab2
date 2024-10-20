using Cremene_Mircea_Adrian_Lab2.Data;
using Cremene_Mircea_Adrian_Lab2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Cremene_Mircea_Adrian_Lab2.Pages.Publishers
{
    public class DetailsModel : PageModel
    {
        private readonly Cremene_Mircea_Adrian_Lab2Context _context;

        public DetailsModel(Cremene_Mircea_Adrian_Lab2Context context)
        {
            _context = context;
        }

        public Publisher Publisher { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publisher = await _context.Publisher.FirstOrDefaultAsync(m => m.Id == id);
            if (publisher == null)
            {
                return NotFound();
            }

            Publisher = publisher;
            return Page();
        }
    }
}
