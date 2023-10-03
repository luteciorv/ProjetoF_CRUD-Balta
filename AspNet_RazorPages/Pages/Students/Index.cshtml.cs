using Microsoft.AspNetCore.Mvc.RazorPages;
using AspNet_RazorPages.ViewModels.Students;
using AspNet_RazorPages.Interfaces.Services;
using AspNet_RazorPages.Extensions;
using Microsoft.AspNetCore.Mvc;

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
