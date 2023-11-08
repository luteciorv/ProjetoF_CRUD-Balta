using ProjetoF.Application.Subscriptions.Commands;
using ProjetoF.Domain.Entities.Subscriptions;
using ProjetoF.Domain.Enums;

namespace ProjetoF.Application.Extensions;

public static class SubscriptionExtension
{
    public static Subscription GetCurrentSubscription(this SubscribeCommand command) =>
        command.Plan switch
        {
            ESubscriptionPlans.MonthlyPlan => new MonthlyPlanSubscription(command.StartDate, command.StudentId),
            ESubscriptionPlans.BimonthlyPlan => new BimonthlyPlanSubscription(command.StartDate, command.StudentId),
            ESubscriptionPlans.QuarterlyPlan => new QuarterlyPlanSubscription(command.StartDate, command.StudentId),
            ESubscriptionPlans.SemiannualPlan => new SemiannualPlanSubscription(command.StartDate, command.StudentId),
            ESubscriptionPlans.YearlyPlan => new YearlyPlanSubscription(command.StartDate, command.StudentId),
            _ => throw new Exception("Nenhuma assinatura associada ao plano informado foi encontrada")
        };
}
