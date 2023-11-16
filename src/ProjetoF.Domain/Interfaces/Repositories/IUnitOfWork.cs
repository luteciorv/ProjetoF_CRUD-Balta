namespace ProjetoF.Domain.Interfaces.Repositories;

public interface IUnitOfWork
{
    ISubscriptionRepository SubscriptionRepository { get; }
    IStudentRepository StudentRepository { get; }

    Task SaveAsync();
}
