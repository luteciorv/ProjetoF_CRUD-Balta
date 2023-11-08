namespace ProjetoF.Application.Subscriptions.DTOs;

public record SubscribeDto(string Title, DateTime StartDate, DateTime EndDate, Guid StudentId);
