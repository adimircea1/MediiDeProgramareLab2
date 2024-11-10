using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cremene_Mircea_Adrian_Lab2.Models;

namespace Cremene_Mircea_Adrian_Lab2.Pages.Borrowings
{
    public class EditModel : PageModel
    {
        private readonly Data.Cremene_Mircea_Adrian_Lab2Context _context;

        public EditModel(Data.Cremene_Mircea_Adrian_Lab2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Borrowing Borrowing { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var borrowing =  await _context.Borrowing.FirstOrDefaultAsync(m => m.Id == id);
            if (borrowing == null)
            {
                return NotFound();
            }
            Borrowing = borrowing;
            
            ViewData["BookData"] = new SelectList(_context.Book.Include(b => b.Author).Select(b => new
            {
                b.Id,
                DisplayText = b.Title + " by " + (b.Author != null ? b.Author.AuthorName : "Unknown Author")
            }), "Id", "DisplayText");
            
            ViewData["MemberData"] = new SelectList(_context.Member, "Id", "FullName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Borrowing).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BorrowingExists(Borrowing.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BorrowingExists(int id)
        {
            return _context.Borrowing.Any(e => e.Id == id);
        }
    }
}
