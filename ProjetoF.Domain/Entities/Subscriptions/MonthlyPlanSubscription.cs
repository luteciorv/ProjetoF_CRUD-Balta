using ProjetoF.Domain.Constants;
using ProjetoF.Domain.Enums;

namespace ProjetoF.Domain.Entities.Subscriptions;

public class MonthlyPlanSubscription : Subscription
{
    public MonthlyPlanSubscription(DateTime startDate, Guid studentId) 
        : base(SubscriptionsPlans.MonthlyPlan, startDate, startDate.AddDays((int) ESubscriptionDuration.MonthlyPlan), studentId)
    {}
}
