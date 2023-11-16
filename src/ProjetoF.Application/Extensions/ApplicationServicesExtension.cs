using FluentValidation;
using MediatR;
using MediatR.NotificationPublishers;
using Microsoft.Extensions.DependencyInjection;
using ProjetoF.Application.Notifications;
using System.Reflection;

namespace ProjetoF.Application.Extensions;

public static class ApplicationServicesExtension
{
    public static void ConfigureApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(typeof(ApplicationServicesExtension).Assembly);
            config.NotificationPublisher = new TaskWhenAllPublisher();
        });
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddScoped<NotificationHandler>();
        services.AddScoped<INotificationHandler<Notification>>(provider => provider.GetRequiredService<NotificationHandler>());
    }
}
