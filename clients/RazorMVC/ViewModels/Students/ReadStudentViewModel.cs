using RazorMVC.ViewModels.Subscriptions;

namespace RazorMVC.ViewModels.Students;

public record ReadStudentViewModel(Guid Id, string Name, string Email, string CreatedAt, IReadOnlyCollection<ReadSubscriptionViewModel> Subscriptions);
