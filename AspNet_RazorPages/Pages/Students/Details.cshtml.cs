using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjetoF.Application.Interfaces;
using ProjetoF.Application.Extensions;

namespace AspNet_RazorPages.Pages.Students
{
    public class DetailsModel : PageModel
    {
        private readonly IStudentService _service;

        public DetailsModel(IStudentService service)
        {
            _service = service;
        }

      public DetailStudentViewModel ViewModel { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            var detailViewModel = await _service.GetByIdAsync(id);
            if (detailViewModel is null) return NotFound();

            ViewModel = detailViewModel;

            return Page();
        }
    }
}
