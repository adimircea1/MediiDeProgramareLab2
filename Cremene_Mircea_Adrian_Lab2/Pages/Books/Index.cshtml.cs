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

        public IList<Book> Book { get; set; } = default!;
        public BookData BookD { get; set; }
        public int BookId { get; set; }
        public int CategoryId { get; set; }

        public string TitleSort { get; set; }
        public string AuthorSort { get; set; }
        public string CurrentFilter { get; set; }

        public async Task OnGetAsync(int? id, int? categoryId, string sortOrder, string searchString)
        {
            TitleSort = string.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            AuthorSort = sortOrder == "author" ? "author_desc" : "author";
            CurrentFilter = searchString;

            BookD = new BookData
            {
                Books = await _context.Book
                    .Include(b => b.Author)
                    .Include(b => b.Publisher)
                    .Include(b => b.BookCategories)!
                    .ThenInclude(b => b.Category)
                    .AsNoTracking()
                    .OrderBy(b => b.Title)
                    .ToListAsync()
            };

            if (!string.IsNullOrEmpty(searchString))
            {
                BookD.Books = BookD.Books
                    .Where(s => s.Author!.FirstName.Contains(searchString) || s.Author.LastName.Contains(searchString) || s.Title.Contains(searchString));
            }

            var books = BookD.Books.ToList();
            
            if (id is not null)
            {
                BookId = id.Value;
                var book = books.Single(i => i.Id == id.Value);
                BookD.Categories = book.BookCategories!.Select(s => s.Category)!;
            }

            switch (sortOrder)
            {
                case "title_desc":
                    BookD.Books = books.OrderByDescending(s => s.Title);
                    break;

                case "author_desc":
                    BookD.Books = books.OrderByDescending(s => s.Author!.AuthorName);
                    break;

                case "author":
                    BookD.Books = books.OrderBy(s => s.Author!.AuthorName);
                    break;

                default:
                    BookD.Books = books.OrderBy(s => s.Title);
                    break;
            }
        }
    }
}