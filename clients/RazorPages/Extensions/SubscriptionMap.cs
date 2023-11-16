using RazorPages.Models;
using RazorPages.ViewModels.Subscriptions;

namespace RazorPages.Extensions;

public static class SubscriptionMap
{
    public static ReadSubscriptionViewModel MapToReadViewModel(this Subscription model) =>
    new(model.Id, model.Title, model.StartDate, model.EndDate);
}
