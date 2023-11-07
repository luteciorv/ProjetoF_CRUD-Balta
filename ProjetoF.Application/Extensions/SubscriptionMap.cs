using ProjetoF.Application.Subscriptions.Commands;
using ProjetoF.Application.Subscriptions.DTOs;
using ProjetoF.Domain.Entities;

namespace ProjetoF.Application.Extensions;

public static class SubscriptionMap
{
    public static Subscription MapToSubscription(this AddSubscriptionCommand command) =>
        new(command.Title, command.StartDate, command.EndDate, command.StudentId);

    public static AddSubscriptionCommand MapToAddCommand(this AddSubscriptionDto dto) =>
       new(dto.StudentId, dto.Title, dto.StartDate, dto.EndDate);

    public static ReadSubscriptionDto MapToReadDto(this Subscription entity) =>
        new(entity.Id, entity.Title, entity.StartDate.ToString("dd/MM/yyyy"), entity.EndDate.ToString("dd/MM/yyyy"));
}
