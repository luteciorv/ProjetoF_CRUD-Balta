using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjetoF.Domain.Interfaces.Repositories;
using ProjetoF.Infrastructure.Persistence.Data;
using ProjetoF.Infrastructure.Persistence.Repositories;

namespace ProjetoF.Infrastructure.Persistence.Extensions;

internal static partial class InfrastructureServicesExtension
{
    public static void ConfigureRepositoriesServices(this IServiceCollection services)
    {
        services.AddScoped<IStudentRepository, StudentRepository>();
        services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }

    public static void ConfigureDatabaseServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("SQLite");
        services.AddDbContext<DataContext>(options => options.UseSqlite(connectionString));
        services.AddDatabaseDeveloperPageExceptionFilter();
    }
}
