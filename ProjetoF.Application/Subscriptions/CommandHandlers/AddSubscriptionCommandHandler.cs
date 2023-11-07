using FluentValidation;
using MediatR;
using ProjetoF.Application.CommandHandler;
using ProjetoF.Application.Extensions;
using ProjetoF.Application.Notifications;
using ProjetoF.Application.Subscriptions.Commands;
using ProjetoF.Domain.Interfaces.Repositories;

namespace ProjetoF.Application.Subscriptions.CommandHandlers;

public class AddSubscriptionCommandHandler : CommandHandlerBase<AddSubscriptionCommand>, IRequestHandler<AddSubscriptionCommand>
{
    public AddSubscriptionCommandHandler(
        IValidator<AddSubscriptionCommand> validator,
        IPublisher publisher,
        NotificationHandler notificationHandler,
        IUnitOfWork unitOfWork
        ) : base(validator, publisher, notificationHandler, unitOfWork)
    { }

    public async Task Handle(AddSubscriptionCommand command, CancellationToken cancellationToken)
    {
        try
        {
            await ValidateAsync(command);
            if (ValidationFailed()) return;

            var subscription = command.MapToSubscription();
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
