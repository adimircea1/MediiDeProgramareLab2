using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Cremene_Mircea_Adrian_Lab2.Models;

namespace Cremene_Mircea_Adrian_Lab2.Pages.Members
{
    public class IndexModel : PageModel
    {
        private readonly Data.Cremene_Mircea_Adrian_Lab2Context _context;

        public IndexModel(Data.Cremene_Mircea_Adrian_Lab2Context context)
        {
            _context = context;
        }

        public IList<Member> Member { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Member = await _context.Member.ToListAsync();
        }
    }
}
