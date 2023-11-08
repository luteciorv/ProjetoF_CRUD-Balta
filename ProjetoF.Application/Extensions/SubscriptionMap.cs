using ProjetoF.Application.Subscriptions.Commands;
using ProjetoF.Application.Subscriptions.DTOs;
using ProjetoF.Domain.Entities.Subscriptions;

namespace ProjetoF.Application.Extensions;

public static class SubscriptionMap
{
    public static SubscribeCommand MapToSubscribeCommand(this SubscribeDto dto) =>
       new(dto.StudentId, dto.Plan, dto.StartDate);

    public static ReadSubscriptionDto MapToReadDto(this Subscription entity) =>
        new(entity.Id, entity.Title, entity.StartDate.ToString("dd/MM/yyyy"), entity.EndDate.ToString("dd/MM/yyyy"));

    public static CancelSubscriptionCommand MapToCancelCommand(this CancelSubscriptionDto dto) =>
        new(dto.StudentId, dto.SubscriptionId);
}
