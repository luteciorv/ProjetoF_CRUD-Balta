using MediatR;

namespace ProjetoF.Application.Notifications
{
    public sealed class NotificationHandler : INotificationHandler<Notification>
    {
        private readonly List<Notification> _notifications;

        public NotificationHandler() 
        {
            _notifications = new List<Notification>();
        }

        public Task Handle(Notification notification, CancellationToken cancellationToken)
        {
            _notifications.Add(notification);
            return Task.CompletedTask;
        }

        public bool HasNotifications() => _notifications.Any();

        public IReadOnlyCollection<Notification> GetAll() => _notifications;
    }
}
