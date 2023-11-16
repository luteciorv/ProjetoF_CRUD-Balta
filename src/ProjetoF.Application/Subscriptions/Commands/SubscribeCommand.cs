using MediatR;
using ProjetoF.Domain.Enums;

namespace ProjetoF.Application.Subscriptions.Commands;

public class SubscribeCommand : IRequest
{
    public SubscribeCommand(Guid studentId, int plan, DateTime startDate)
    {
        StudentId = studentId;
        Plan = (ESubscriptionPlans) plan;
        StartDate = startDate;
    }

    public Guid StudentId { get; private set; }
    public ESubscriptionPlans Plan { get; private set; }
    public DateTime StartDate { get; private set; }
}
