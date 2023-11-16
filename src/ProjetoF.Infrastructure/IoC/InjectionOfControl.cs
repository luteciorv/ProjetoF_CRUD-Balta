using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjetoF.Infrastructure.Persistence.Extensions;
using ProjetoF.Infrastructure.Security.Extensions;

namespace ProjetoF.Infrastructure.IoC;

public static class InjectionOfControl
{
    public static void ConfigureInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.ConfigureRepositoriesServices();
        services.ConfigureDatabaseServices(configuration);
        services.ConfigureIdentityServices();
    }
}
