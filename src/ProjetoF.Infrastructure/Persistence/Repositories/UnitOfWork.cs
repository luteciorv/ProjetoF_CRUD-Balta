using MediatR;
using Microsoft.Extensions.Logging;
using ProjetoF.Application.Notifications;
using ProjetoF.Domain.Interfaces.Repositories;
using ProjetoF.Infrastructure.Persistence.Data;

namespace ProjetoF.Infrastructure.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    public ISubscriptionRepository SubscriptionRepository { get; private set; }
    public IStudentRepository StudentRepository {get; private set; }

    private readonly DataContext _dataContext;
    private readonly ILogger<UnitOfWork> _logger;
    private readonly IPublisher _publisher;

    public UnitOfWork(
        DataContext dataContext,
        ILogger<UnitOfWork> logger,
        IPublisher publisher)
    {
        _dataContext = dataContext;
        _logger = logger;
        _publisher = publisher;

        SubscriptionRepository = new SubscriptionRepository(dataContext);
        StudentRepository = new StudentRepository(dataContext);
    }

    public async Task SaveAsync()
    {
        try
        {
            await _dataContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            var notification = new Notification("Database", "Um erro inesperado ocorreu ao tentar persistir os dados no banco de dados");
            await _publisher.Publish(notification);
            _logger.LogError(ex, $"Não foi possível persistir os dados no banco de dados. Exceção: {ex.Message}");
        }
    }
}
