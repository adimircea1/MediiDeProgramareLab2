using Cremene_Mircea_Adrian_Lab2.Data;
using Cremene_Mircea_Adrian_Lab2.Models;
using Cremene_Mircea_Adrian_Lab2.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Cremene_Mircea_Adrian_Lab2.Pages.Publishers
{
    public class IndexModel : PageModel
    {
        private readonly Cremene_Mircea_Adrian_Lab2Context _context;

        public IndexModel(Cremene_Mircea_Adrian_Lab2Context context)
        {
            _context = context;
        }

        public IList<Publisher> Publisher { get;set; } = default!;
        public PublisherIndexData? PublisherData { get; set; }
        public int PublisherId { get; set; }
        public int BookId { get; set; }
        
        public async Task OnGetAsync(int? id, int? bookId)
        {
            PublisherData = new PublisherIndexData
            {
                Publishers = await _context.Publisher
                    .Include(i => i.Books)!
                    .ThenInclude(c => c.Author)
                    .OrderBy(i => i.PublisherName)
                    .ToListAsync()
            };

            if (id is not null)
            {
                PublisherId = id.Value;
                var publisher = PublisherData.Publishers
                    .Single(i => i.Id == id.Value);

                PublisherData.Books = publisher.Books;
            }
            
            Publisher = await _context.Publisher.ToListAsync();
        }
    }
}
