using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Cremene_Mircea_Adrian_Lab2.Models;
using Microsoft.EntityFrameworkCore;

namespace Cremene_Mircea_Adrian_Lab2.Pages.Borrowings
{
    public class CreateModel : PageModel
    {
        private readonly Data.Cremene_Mircea_Adrian_Lab2Context _context;

        public CreateModel(Data.Cremene_Mircea_Adrian_Lab2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var bookList = _context.Book
                .Include(b => b.Author)
                .Select(x => new
                {
                    x.Id,
                    BookFullName = x.Title + " - " + x.Author!.AuthorName
                });
            
            ViewData["BookId"] = new SelectList(bookList, "Id", "BookFullName");
            ViewData["MemberId"] = new SelectList(bookList, "Id", "FullName");
            return Page();
        }

        [BindProperty] public Borrowing Borrowing { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Borrowing.Add(Borrowing);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}