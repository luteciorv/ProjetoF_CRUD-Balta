using RazorPages.Models;

namespace RazorPages.Interfaces
{
    public interface IStudentClient
    {
        Task<IReadOnlyCollection<Student>> GetAsync();
    }
}
