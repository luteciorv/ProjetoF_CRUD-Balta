using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AspNet_RazorPages.Interfaces.Services;
using AspNet_RazorPages.ViewModels.Students;
using AspNet_RazorPages.Extensions;

namespace AspNet_RazorPages.Pages.Students
{
    public class EditModel : PageModel
    {
        private readonly IStudentService _service;

        public EditModel(IStudentService service)
        {
            _service = service;
        }

        [BindProperty]
        public EditStudentViewModel EditViewModel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var readViewModel = await _service.GetByIdAsync(id);
            if (readViewModel is null) return NotFound();

            EditViewModel = readViewModel.MapToEditViewModel();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            await _service.EditAsync(EditViewModel);

            return RedirectToPage("./Index");
        }
    }
}
