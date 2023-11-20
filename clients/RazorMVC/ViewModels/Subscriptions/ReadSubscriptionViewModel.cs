namespace RazorMVC.ViewModels.Subscriptions;

public class ReadSubscriptionViewModel(Guid id, string title, string startDate, string endDate)
{
    public Guid Id { get; private set; } = id;
    public string Title { get; private set; } = title;
    public string StartDate { get; private set; } = startDate;
    public string EndDate { get; private set; } = endDate;

    public string GetPeriod() => $"{StartDate} - {EndDate}";
}