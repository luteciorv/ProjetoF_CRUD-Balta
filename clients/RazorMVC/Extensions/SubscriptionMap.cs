using RazorMVC.Models;
using RazorMVC.ViewModels.Subscriptions;

namespace RazorMVC.Extensions;

public static class SubscriptionMap
{
    public static ReadSubscriptionViewModel MapToReadViewModel(this Subscription model) =>
    new(model.Id, model.Title, model.StartDate, model.EndDate);
}
