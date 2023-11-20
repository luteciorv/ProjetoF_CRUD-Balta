using RazorMVC.Models;

namespace RazorMVC.Interfaces
{
    public interface IStudentClient
    {
        Task<IReadOnlyCollection<Student>> GetAsync();
    }
}
