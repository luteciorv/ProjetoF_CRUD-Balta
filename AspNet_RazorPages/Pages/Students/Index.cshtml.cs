using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AspNet_RazorPages.Data;
using AspNet_RazorPages.Entities;

namespace AspNet_RazorPages.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Student> Student { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Students != null)
            {
                Student = await _context.Students.ToListAsync();
            }
        }
    }
}
