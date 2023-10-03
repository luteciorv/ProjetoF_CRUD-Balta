using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AspNet_RazorPages.Data;
using AspNet_RazorPages.Entities;

namespace AspNet_RazorPages.Pages.Subscriptions
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

      public Subscription Subscription { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Subscriptions == null)
            {
                return NotFound();
            }

            var subscription = await _context.Subscriptions.FirstOrDefaultAsync(m => m.Id == id);
            if (subscription == null)
            {
                return NotFound();
            }
            else 
            {
                Subscription = subscription;
            }
            return Page();
        }
    }
}
