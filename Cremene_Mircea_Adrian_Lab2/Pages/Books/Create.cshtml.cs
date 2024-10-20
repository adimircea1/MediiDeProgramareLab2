using Cremene_Mircea_Adrian_Lab2.Data;
using Cremene_Mircea_Adrian_Lab2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cremene_Mircea_Adrian_Lab2.Pages.Books
{
    public class CreateModel : PageModel
    {
        private readonly Cremene_Mircea_Adrian_Lab2Context _context;

        public CreateModel(Cremene_Mircea_Adrian_Lab2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["PublisherId"] = new SelectList(_context.Set<Publisher>(), "Id",
                "PublisherName");

            ViewData["AuthorId"] = new SelectList(_context.Set<Author>(), "Id", "AuthorName");
            
            return Page();
        }

        [BindProperty]
        public Book Book { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Book.Add(Book);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
