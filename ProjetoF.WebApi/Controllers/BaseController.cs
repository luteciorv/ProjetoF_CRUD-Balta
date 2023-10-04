using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjetoF.Application.Notifications;

namespace ProjetoF.WebApi.Controllers
{
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected readonly ISender Sender;
        private readonly NotificationHandler _notificationHandler;

        public BaseController(ISender mediator, NotificationHandler notificationHandler)
        {
            Sender = mediator;
            _notificationHandler = notificationHandler;
        }

        protected bool Success() => !_notificationHandler.HasNotifications();

        protected IDictionary<string, string> GetNotifications()
        {
            return _notificationHandler.GetAll().ToDictionary(n => n.Key, n => n.Value);
        }
    }
}
