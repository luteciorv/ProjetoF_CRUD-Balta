using FluentValidation;
using MediatR;
using ProjetoF.Application.Notifications;
using ProjetoF.Domain.Interfaces.Repositories;

namespace ProjetoF.Application.CommandHandler
{
    public abstract class CommandHandlerBase<TCommand> where TCommand : IRequest
    {
        private readonly IValidator<TCommand> _validator;
        private readonly IPublisher _publisher;
        private readonly NotificationHandler _notificationHandler;
        protected readonly IUnitOfWork UnitOfWork;

        protected CommandHandlerBase(
            IValidator<TCommand> validator, 
            IPublisher publisher, 
            NotificationHandler notificationHandler,
            IUnitOfWork unitOfWork)
        {
            _validator = validator;
            _publisher = publisher;
            _notificationHandler = notificationHandler;
            UnitOfWork = unitOfWork;
        }

        protected async Task ValidateAsync(TCommand command)
        {
            var result = await _validator.ValidateAsync(command);
            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                    await NotifyEventAsync(error.PropertyName, error.ErrorMessage);
            }
        }

        protected async Task NotifyEventAsync(string key, string value)
        {
            var notification = new Notification(key, value);
            await _publisher.Publish(notification);
        }

        protected bool ValidationFailed() => _notificationHandler.HasNotifications();
    }
}
