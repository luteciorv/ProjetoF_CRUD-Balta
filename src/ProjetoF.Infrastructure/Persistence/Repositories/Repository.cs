using AspNet_RazorPages.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using ProjetoF.Domain.Entities;
using ProjetoF.Infrastructure.Persistence.Data;

namespace ProjetoF.Infrastructure.Persistence.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : EntityBase
{
    protected readonly DataContext Context;

    public Repository(DataContext context)
    {
        Context = context;
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync() =>
        await Context.Set<TEntity>()
                    .AsNoTracking()
                    .ToListAsync();

    public virtual async Task<TEntity?> GetByIdAsync(Guid id) =>
        await Context.Set<TEntity>()
                    .AsNoTracking()
                    .Where(e => e.Enabled)
                    .FirstOrDefaultAsync(e => e.Id == id);

    public async Task<bool> ExistsAsync(Guid id) =>
        (await GetByIdAsync(id)) is not null;

    public async Task AddAsync(TEntity entity) =>
        await Context.Set<TEntity>().AddAsync(entity);

    public void Update(TEntity entity)
    {
        Context.Entry(entity).State = EntityState.Modified;
        Context.Set<TEntity>().Update(entity);
    }

    public void Delete(TEntity entity)
    {
        Context.Set<TEntity>().Remove(entity);
    }
}
