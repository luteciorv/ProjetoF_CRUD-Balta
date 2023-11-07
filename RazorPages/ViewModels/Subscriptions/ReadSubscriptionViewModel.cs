namespace RazorPages.ViewModels.Subscriptions;

public class ReadSubscriptionViewModel
{
    public ReadSubscriptionViewModel(Guid id, string title, string startDate, string endDate)
    {
        Id = id;
        Title = title;
        StartDate = startDate;
        EndDate = endDate;
    }

    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public string StartDate { get; private set; }
    public string EndDate { get; private set; }

    public string GetPeriod() => $"{StartDate} - {EndDate}";
}