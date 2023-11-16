using ProjetoF.Domain.Constants;
using ProjetoF.Domain.Enums;

namespace ProjetoF.Domain.Entities.Subscriptions;

public class BimonthlyPlanSubscription : Subscription
{
    public BimonthlyPlanSubscription(DateTime startDate, Guid studentId)
        : base(SubscriptionsPlans.BimonthlyPlan, startDate, startDate.AddDays((int)ESubscriptionDuration.BimonthlyPlan), studentId)
    { }
}
