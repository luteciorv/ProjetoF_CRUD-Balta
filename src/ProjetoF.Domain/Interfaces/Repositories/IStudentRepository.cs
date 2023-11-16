using AspNet_RazorPages.Interfaces.Repositories;
using ProjetoF.Domain.Entities;

namespace ProjetoF.Domain.Interfaces.Repositories;

public interface IStudentRepository : IRepository<Student>
{
    Task<Student?> GetByEmailAsync(string email);
}
