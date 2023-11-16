using ProjetoF.Domain.Constants;
using ProjetoF.Domain.Enums;

namespace ProjetoF.Domain.Entities.Subscriptions;

public class SemiannualPlanSubscription : Subscription
{
    public SemiannualPlanSubscription(DateTime startDate, Guid studentId)
        : base(SubscriptionsPlans.SemiannualPlan, startDate, startDate.AddDays((int)ESubscriptionDuration.SemiannualPlan), studentId)
    { }
}
