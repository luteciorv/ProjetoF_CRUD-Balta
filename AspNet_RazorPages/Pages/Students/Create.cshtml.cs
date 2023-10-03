using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AspNet_RazorPages.Interfaces.Services;
using AspNet_RazorPages.ViewModels.Students;

namespace AspNet_RazorPages.Pages.Students
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public CreateStudentViewModel ViewModel { get; set; } = default!;

        private readonly IStudentService _service;

        public CreateModel(IStudentService service)
        {
            _service = service;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            await _service.CreateAsync(ViewModel);

            return RedirectToPage("./Index");
        }
    }
}
