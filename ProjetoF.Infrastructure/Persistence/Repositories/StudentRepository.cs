using Microsoft.EntityFrameworkCore;
using ProjetoF.Domain.Entities;
using ProjetoF.Domain.Interfaces.Repositories;
using ProjetoF.Infrastructure.Persistence.Data;

namespace ProjetoF.Infrastructure.Persistence.Repositories;

public class StudentRepository : Repository<Student>, IStudentRepository
{
    public StudentRepository(DataContext context) : base(context)
    {
    }

    public override async Task<IEnumerable<Student>> GetAllAsync() =>
         await Context.Students
            .AsNoTracking()
            .Where(s => s.Enabled)
            .Include(s => s.Subscriptions)
            .ToListAsync();

    public override async Task<Student?> GetByIdAsync(Guid id) =>
        await Context.Students
            .AsNoTracking()
            .Where(s => s.Enabled)
            .Include(s => s.Subscriptions)
            .FirstOrDefaultAsync(s => s.Id == id);

    public async Task<Student?> GetByEmailAsync(string email) =>
        await Context.Students
            .AsNoTracking()
            .Where(s => s.Enabled)
            .FirstOrDefaultAsync(s => s.Email.ToLower() == email.ToLower());
}
