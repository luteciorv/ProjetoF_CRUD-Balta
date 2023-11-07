using RazorPages.ViewModels.Subscriptions;

namespace RazorPages.ViewModels.Students;

public record ReadStudentViewModel(Guid Id, string Name, string Email, IReadOnlyCollection<ReadSubscriptionViewModel> Subscriptions);
