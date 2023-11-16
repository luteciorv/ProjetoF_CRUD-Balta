using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjetoF.Application.Notifications;
using System.Net;

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

        protected new IActionResult Response(HttpStatusCode statusCode, object? result = null)
        {
            if (Success())
            {
                return statusCode switch
                {
                    HttpStatusCode.Created => Created(string.Empty, result),
                    HttpStatusCode.NoContent => NoContent(),
                    _ => Ok(result)
                };
            }

            var notifications = GetNotifications();
            var errors = notifications.Select(n => n.Value);
            int errorCode = int.Parse(notifications.FirstOrDefault().Key);

            return errorCode switch
            {
                (int)HttpStatusCode.NotFound => NotFound(errors),
                (int)HttpStatusCode.BadRequest => BadRequest(errors),
                _ => StatusCode((int)HttpStatusCode.InternalServerError, errors),
            };
        }
    }
}
