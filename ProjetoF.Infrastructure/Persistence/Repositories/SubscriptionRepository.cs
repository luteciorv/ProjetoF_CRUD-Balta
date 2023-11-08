using ProjetoF.Domain.Entities.Subscriptions;
using ProjetoF.Domain.Interfaces.Repositories;
using ProjetoF.Infrastructure.Persistence.Data;

namespace ProjetoF.Infrastructure.Persistence.Repositories;

public class SubscriptionRepository : Repository<Subscription>, ISubscriptionRepository
{
    public SubscriptionRepository(DataContext context) : base(context)
    {
    }
}
