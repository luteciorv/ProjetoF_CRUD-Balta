using ProjetoF.Domain.Constants;
using ProjetoF.Domain.Enums;

namespace ProjetoF.Domain.Entities.Subscriptions;

public class YearlyPlanSubscription : Subscription
{
    public YearlyPlanSubscription(DateTime startDate, Guid studentId)
   : base(SubscriptionsPlans.YearlyPlan, startDate, startDate.AddDays((int)ESubscriptionDuration.YearlyPlan), studentId)
    { }
}
