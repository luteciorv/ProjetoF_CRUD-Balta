using RazorMVC.Clients;
using RazorMVC.Interfaces;
using RazorMVC.Settings;

namespace RazorMVC.Extensions
{
    public static class ClientServicesExtension
    {
        public static void ConfigureServicesExtension(this IServiceCollection services, IConfiguration configuration)
        {
            var apiSettings = configuration.GetSection(nameof(ApiSettings)).Get<ApiSettings>();

            services.AddHttpClient<IStudentClient, StudentClient>(client =>
            {
                client.BaseAddress = new Uri(apiSettings!.StudentsUrl);
            });
        }
    }
}
