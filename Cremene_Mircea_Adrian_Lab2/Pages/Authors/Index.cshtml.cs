using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Cremene_Mircea_Adrian_Lab2.Data;
using Cremene_Mircea_Adrian_Lab2.Models;

namespace Cremene_Mircea_Adrian_Lab2.Pages.Authors
{
    public class IndexModel : PageModel
    {
        private readonly Cremene_Mircea_Adrian_Lab2.Data.Cremene_Mircea_Adrian_Lab2Context _context;

        public IndexModel(Cremene_Mircea_Adrian_Lab2.Data.Cremene_Mircea_Adrian_Lab2Context context)
        {
            _context = context;
        }

        public IList<Author> Author { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Author = await _context.Author.ToListAsync();
        }
    }
}
