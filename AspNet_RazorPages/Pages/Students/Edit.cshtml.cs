using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjetoF.Application.Interfaces;
using ProjetoF.Application.Extensions;

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

        public async Task<IActionResult> OnGetAsync([FromRoute] Guid id)
        {
            var readViewModel = await _service.GetByIdAsync(id);
            if (readViewModel is null) return NotFound();

            EditViewModel = readViewModel.MapToEditViewModel();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync([FromForm] Guid id)
        {
            if (!ModelState.IsValid) return Page();

            await _service.EditAsync(id, EditViewModel);

            return RedirectToPage("./Index");
        }
    }
}
