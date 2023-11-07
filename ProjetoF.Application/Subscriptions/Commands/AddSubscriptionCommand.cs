using MediatR;

namespace ProjetoF.Application.Subscriptions.Commands;

public class AddSubscriptionCommand : IRequest
{
    public AddSubscriptionCommand(Guid studentId, string title, DateTime startDate, DateTime endDate)
    {
        StudentId = studentId;
        Title = title;
        StartDate = startDate;
        EndDate = endDate;
    }

    public Guid StudentId { get; private set; }
    public string Title { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
}
