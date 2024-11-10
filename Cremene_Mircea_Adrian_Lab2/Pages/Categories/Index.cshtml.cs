using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Cremene_Mircea_Adrian_Lab2.Models;
using Cremene_Mircea_Adrian_Lab2.Models.ViewModels;

namespace Cremene_Mircea_Adrian_Lab2.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Data.Cremene_Mircea_Adrian_Lab2Context _context;

        public IndexModel(Data.Cremene_Mircea_Adrian_Lab2Context context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; } = default!;
        public CategoryIndexData? CategoryData { get; set; }
        public int CategoryId { get; set; }
        public int BookId { get; set; }

        public async Task OnGetAsync(int? id, int? bookId)
        {
            CategoryData = new CategoryIndexData
            {
                Categories = await _context.Category
                    .Include(i => i.BookCategories)!
                    .ThenInclude(i => i.Book)
                    .ThenInclude(i => i!.Author)
                    .OrderBy(i => i.CategoryName)
                    .ToListAsync()
            };

            if (id is not null)
            {
                CategoryId = id.Value;
                var category = CategoryData.Categories
                    .Single(i => i.Id == id.Value);

                CategoryData.Books = category.BookCategories!.Select(bc => bc.Book)
                    .ToList()!;
            }
            
            Category = await _context.Category.ToListAsync();
        }
    }
}
