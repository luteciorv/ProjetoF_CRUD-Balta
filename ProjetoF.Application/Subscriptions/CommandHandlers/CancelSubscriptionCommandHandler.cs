using FluentValidation;
using MediatR;
using ProjetoF.Application.CommandHandler;
using ProjetoF.Application.Notifications;
using ProjetoF.Application.Subscriptions.Commands;
using ProjetoF.Domain.Interfaces.Repositories;

namespace ProjetoF.Application.Subscriptions.CommandHandlers;

public class CancelSubscriptionCommandHandler : CommandHandlerBase<CancelSubscriptionCommand>, IRequestHandler<CancelSubscriptionCommand>
{
    public CancelSubscriptionCommandHandler(
        IValidator<CancelSubscriptionCommand> validator,
        IPublisher publisher,
        NotificationHandler notificationHandler,
        IUnitOfWork unitOfWork
        ) : base(validator, publisher, notificationHandler, unitOfWork)
    {
    }

    public async Task Handle(CancelSubscriptionCommand command, CancellationToken cancellationToken)
    {
        try
        {
            await ValidateAsync(command);
            if (ValidationFailed()) return;

            var student = (await UnitOfWork.StudentRepository.GetByIdAsync(command.StudentId))!;
            var subscription = (await UnitOfWork.SubscriptionRepository.GetByIdAsync(command.SubscriptionId))!;

            UnitOfWork.SubscriptionRepository.Delete(subscription);
            student.RemoveSubscription(subscription.Id);
            UnitOfWork.StudentRepository.Update(student);

            await UnitOfWork.SaveAsync();
        }
        catch (Exception ex)
        {
            await NotifyEventAsync("Error", ex.Message);
        }
    }
}
