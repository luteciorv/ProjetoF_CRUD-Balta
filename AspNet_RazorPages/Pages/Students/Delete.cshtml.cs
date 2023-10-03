using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AspNet_RazorPages.ViewModels.Students;
using AspNet_RazorPages.Interfaces.Services;
using AspNet_RazorPages.Extensions;

namespace AspNet_RazorPages.Pages.Students
{
    public class DeleteModel : PageModel
    {
        private readonly IStudentService _service;

        public DeleteModel(IStudentService service)
        {
            _service = service;
        }

        public ReadStudentViewModel ReadViewModel { get; set; } = default!;
        
        [BindProperty]
        public int Id { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var readViewModel = await _service.GetByIdAsync(id);
            if (readViewModel is null) return NotFound();

            ReadViewModel = readViewModel.MapToReadViewModel();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            await _service.DeleteAsync(id);

            return RedirectToPage("./Index");
        }
    }
}
