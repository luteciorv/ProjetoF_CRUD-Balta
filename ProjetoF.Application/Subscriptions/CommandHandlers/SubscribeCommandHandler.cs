using FluentValidation;
using MediatR;
using ProjetoF.Application.CommandHandler;
using ProjetoF.Application.Extensions;
using ProjetoF.Application.Notifications;
using ProjetoF.Application.Subscriptions.Commands;
using ProjetoF.Domain.Interfaces.Repositories;

namespace ProjetoF.Application.Subscriptions.CommandHandlers;

public class SubscribeCommandHandler : CommandHandlerBase<SubscribeCommand>, IRequestHandler<SubscribeCommand>
{
    public SubscribeCommandHandler(
        IValidator<SubscribeCommand> validator,
        IPublisher publisher,
        NotificationHandler notificationHandler,
        IUnitOfWork unitOfWork
        ) : base(validator, publisher, notificationHandler, unitOfWork)
    { }

    public async Task Handle(SubscribeCommand command, CancellationToken cancellationToken)
    {
        try
        {
            await ValidateAsync(command);
            if (ValidationFailed()) return;

            var subscription = command.MapToEntity();
            await UnitOfWork.SubscriptionRepository.AddAsync(subscription);

            var student = await UnitOfWork.StudentRepository.GetByIdAsync(command.StudentId);
            student!.AddSubscription(subscription);
            UnitOfWork.StudentRepository.Update(student);

            await UnitOfWork.SaveAsync();
        }
        catch(Exception ex)
        {
            await NotifyEventAsync("Error", ex.Message);
        }
    }
}
