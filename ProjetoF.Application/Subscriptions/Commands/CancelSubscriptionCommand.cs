using MediatR;

namespace ProjetoF.Application.Subscriptions.Commands;

public class CancelSubscriptionCommand : IRequest
{
    public CancelSubscriptionCommand(Guid studentId, Guid subscriptionId)
    {
        StudentId = studentId;
        SubscriptionId = subscriptionId;
    }

    public Guid StudentId { get; private set; }
    public Guid SubscriptionId { get; private set; }
}
