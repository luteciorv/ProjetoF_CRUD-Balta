using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using ProjetoF.Application.Interfaces;
using ProjetoF.Application.Extensions;

namespace AspNet_RazorPages.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly IStudentService _service;

        public IndexModel(IStudentService service)
        {
            _service = service;
        }

        public IReadOnlyCollection<ReadStudentViewModel> ReadViewModels { get;set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            var detailViewModels = await _service.GetAllAsync();
            ReadViewModels = detailViewModels.Select(vm => vm.MapToReadViewModel()).ToArray();

            return Page();
        }
    }
}
