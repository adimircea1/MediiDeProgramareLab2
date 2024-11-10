using Cremene_Mircea_Adrian_Lab2.Data;
using Cremene_Mircea_Adrian_Lab2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cremene_Mircea_Adrian_Lab2.Pages.Books
{
    public class CreateModel : BookCategoriesPageModel
    {
        private readonly Cremene_Mircea_Adrian_Lab2Context _context;

        public CreateModel(Cremene_Mircea_Adrian_Lab2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["PublisherId"] = new SelectList(_context.Set<Publisher>(), "Id", "PublisherName");

            //AuthorName => FirstName + " " + LastName
            ViewData["AuthorId"] = new SelectList(_context.Set<Author>(), "Id", "AuthorName");

            var book = new Book
            {
                BookCategories = new List<BookCategory>()
            };

            PopulateAssignedCategoryData(_context, book);
            return Page();
        }

        [BindProperty]
        public Book Book { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[]? selectedCategories)
        {
            var newBook = new Book();
            if (selectedCategories is not null)
            {
                newBook.BookCategories = new List<BookCategory>();
                foreach (var selectedCategory in selectedCategories)
                {
                    var categoryToAdd = new BookCategory
                    {
                        CategoryId = int.Parse(selectedCategory)
                    };
                    newBook.BookCategories.Add(categoryToAdd);
                }
            }

            Book.BookCategories = newBook.BookCategories;
            _context.Book.Add(Book);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
