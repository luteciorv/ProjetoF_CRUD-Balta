using RazorPages.Clients;
using RazorPages.Interfaces;
using RazorPages.Settings;

namespace RazorPages.Extensions
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
