using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProjetoF.Domain.Entities;
using ProjetoF.Domain.Interfaces.Repositories;
using ProjetoF.Infrastructure.Persistence.Data;

namespace ProjetoF.Infrastructure.Persistence.Repositories
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(
            DataContext context, 
            ILogger<StudentRepository> logger, 
            IPublisher publisher) 
            : base(context, logger, publisher)
        {
        }

        public async Task<Student?> GetByEmailAsync(string email)
        {
            return await Context.Students
                .AsNoTracking()
                .Where(s => s.Enabled)
                .FirstOrDefaultAsync(s => s.Email.ToLower() == email.ToLower());
        }
    }
}
