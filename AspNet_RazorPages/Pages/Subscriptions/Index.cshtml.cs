using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AspNet_RazorPages.Data;
using AspNet_RazorPages.Entities;

namespace AspNet_RazorPages.Pages.Subscriptions
{
    public class IndexModel : PageModel
    {
        private readonly Data.DataContext _context;

        public IndexModel(Data.DataContext context)
        {
            _context = context;
        }

        public IList<Subscription> Subscription { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Subscriptions != null)
            {
                Subscription = await _context.Subscriptions
                .Include(s => s.Student).ToListAsync();
            }
        }
    }
}
