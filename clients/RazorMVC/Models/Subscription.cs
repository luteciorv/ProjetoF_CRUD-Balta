namespace RazorMVC.Models;

public class Subscription
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string StartDate { get; set; } = string.Empty;
    public string EndDate { get; set; } = string.Empty;
}
