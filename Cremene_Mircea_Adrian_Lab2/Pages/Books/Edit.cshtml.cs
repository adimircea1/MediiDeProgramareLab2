using Cremene_Mircea_Adrian_Lab2.Data;
using Cremene_Mircea_Adrian_Lab2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Cremene_Mircea_Adrian_Lab2.Pages.Books
{
    public class EditModel : BookCategoriesPageModel
    {
        private readonly Cremene_Mircea_Adrian_Lab2Context _context;

        public EditModel(Cremene_Mircea_Adrian_Lab2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Book Book { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book =  await _context.Book
                .Include(b => b.Publisher)
                .Include(b => b.BookCategories)!
                .ThenInclude(b => b.Category)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
            
            if (book == null)
            {
                return NotFound();
            }
            
            Book = book;
            
            PopulateAssignedCategoryData(_context, Book);
            
            ViewData["PublisherId"] = new SelectList(_context.Set<Publisher>(), "Id", "PublisherName");
            ViewData["AuthorId"] = new SelectList(_context.Set<Author>(), "Id", "AuthorName");

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)
        {
            if (id is null)
            {
                return NotFound();
            }

            var bookToUpdate = await _context.Book
                .Include(i => i.Publisher)
                .Include(i => i.BookCategories)!
                .ThenInclude(i => i.Category)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (bookToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync(bookToUpdate, "Book", i => i.Title,
                    i => i.Author, i => i.Price, i => i.PublishingDate, i => i.PublisherId))
            {
                UpdateBookCategories(_context, selectedCategories, bookToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            
            UpdateBookCategories(_context, selectedCategories, bookToUpdate);
            PopulateAssignedCategoryData(_context, bookToUpdate);
            return Page();
        }

        private bool BookExists(int id)
        {
            return _context.Book.Any(e => e.Id == id);
        }
    }
}
