using ProjetoF.Domain.Constants;
using ProjetoF.Domain.Enums;

namespace ProjetoF.Domain.Entities.Subscriptions;

public class QuarterlyPlanSubscription : Subscription
{
    public QuarterlyPlanSubscription(DateTime startDate, Guid studentId)
        : base(SubscriptionsPlans.QuarterlyPlan, startDate, startDate.AddDays((int)ESubscriptionDuration.QuarterlyPlan), studentId)
    { }
}
