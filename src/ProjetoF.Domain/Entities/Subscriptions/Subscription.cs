namespace ProjetoF.Domain.Entities.Subscriptions;

public class Subscription : EntityBase
{
    public Subscription(string title, DateTime startDate, DateTime endDate, Guid studentId)
    {
        Title = title;
        StartDate = startDate;
        EndDate = endDate;
        StudentId = studentId;
    }

    public string Title { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }

    public Guid StudentId { get; private set; }
    public Student Student { get; private set; } = null!;

    public bool DatesBehind(DateTime startDate, DateTime endDate) =>
        startDate >= StartDate && endDate <= EndDate;
}