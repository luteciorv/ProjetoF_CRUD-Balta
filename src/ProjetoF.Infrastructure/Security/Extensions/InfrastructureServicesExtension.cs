using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using ProjetoF.Infrastructure.Persistence.Data;

namespace ProjetoF.Infrastructure.Security.Extensions
{
    public static partial class InfrastructureServicesExtension
    {
        internal static void ConfigureIdentityServices(this IServiceCollection services)
        {
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<DataContext>();
        }
    }
}
