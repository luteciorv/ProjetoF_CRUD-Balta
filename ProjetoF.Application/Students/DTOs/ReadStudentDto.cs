using ProjetoF.Application.Subscriptions.DTOs;

namespace ProjetoF.Application.Students.DTOs;

public record ReadStudentDto(Guid Id, string Name, string Email, string CreatedAt, IReadOnlyCollection<ReadSubscriptionDto> Subscriptions);
