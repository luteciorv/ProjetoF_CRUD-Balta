namespace ProjetoF.Application.Subscriptions.DTOs;

public record AddSubscriptionDto(string Title, DateTime StartDate, DateTime EndDate, Guid StudentId);
