using RazorPages.Models;
using RazorPages.ViewModels.Students;

namespace RazorPages.Interfaces
{
    public interface IStudentClient
    {
        Task<IReadOnlyCollection<Student>?> GetAsync();
        Task<DetailStudentViewModel> GetAsync(Guid id);
        Task PostAsync(CreateStudentInputModel viewModel);
        Task PutAsync(EditStudentInputModel viewModel);
        Task DeleteAsync(Guid id);
    }
}
