using AspNet_RazorPages.ViewModels.Students;

namespace AspNet_RazorPages.Interfaces.Services
{
    public interface IStudentService
    {
        Task<IReadOnlyCollection<DetailStudentViewModel>> GetAllAsync();
        Task<DetailStudentViewModel?> GetByIdAsync(int id);

        Task CreateAsync(CreateStudentViewModel viewModel);
        Task EditAsync(EditStudentViewModel viewModel);
        Task DeleteAsync(int id);
    }
}
