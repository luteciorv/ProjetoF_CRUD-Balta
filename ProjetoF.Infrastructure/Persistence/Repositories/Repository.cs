using AspNet_RazorPages.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProjetoF.Application.Notifications;
using ProjetoF.Domain.Entities;
using ProjetoF.Infrastructure.Persistence.Data;

namespace ProjetoF.Infrastructure.Persistence.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : EntityBase
{
    protected readonly DataContext Context;
    private readonly ILogger<Repository<TEntity>> _logger;
    private readonly IPublisher _publisher;

    public Repository(
        DataContext context, 
        ILogger<Repository<TEntity>> logger,
        IPublisher publisher)
    {
        Context = context;
        _logger = logger;
        _publisher = publisher;
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync() =>
        await Context.Set<TEntity>()
                    .AsNoTracking()
                    .ToListAsync();

    public async Task<TEntity?> GetByIdAsync(Guid id) =>
        await Context.Set<TEntity>()
                    .AsNoTracking()
                    .Where(e => e.Enabled)
                    .FirstOrDefaultAsync(e => e.Id == id);

    public async Task AddAsync(TEntity entity) =>
        await Context.Set<TEntity>().AddAsync(entity);

    public void Update(TEntity entity)
    {
        Context.Entry(entity).State = EntityState.Modified;
        Context.Set<TEntity>().Update(entity);
    }

    public async Task SaveAsync()
    {
        try
        {
            await Context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            var notification = new Notification("Database", "Um erro inesperado ocorreu ao tentar persistir os dados no banco de dados");
            await _publisher.Publish(notification);
            _logger.LogError($"Não foi possível persistir os dados no banco de dados. Exceção: {ex.Message}", ex);
        }
    }
}
