using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using RazorPages.Interfaces;
using RazorPages.ViewModels.Students;
using RazorPages.Extensions;

namespace RazorPages.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly IStudentClient _client;

        public IndexModel(IStudentClient service)
        {
            _client = service;
        }

        public IReadOnlyCollection<ReadStudentViewModel> ViewModels { get;set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            var students = await _client.GetAsync();
            
            if (students is null || students.Count == 0) ViewModels = new List<ReadStudentViewModel>();
            else ViewModels = students.Select(s => s.MapToReadViewModel()).ToArray();

            return Page();
        }
    }
}
