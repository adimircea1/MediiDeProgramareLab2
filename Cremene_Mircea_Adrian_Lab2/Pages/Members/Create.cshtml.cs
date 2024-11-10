using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Cremene_Mircea_Adrian_Lab2.Models;

namespace Cremene_Mircea_Adrian_Lab2.Pages.Members
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
            return Page();
        }

        [BindProperty]
        public Member Member { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Member.Add(Member);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
