using AspNet_RazorPages.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjetoF.Domain.Entities;
using ProjetoF.Infrastructure.Persistence.Data;
using ProjetoF.Infrastructure.Persistence.Repositories;

namespace ProjetoF.Infrastructure.Persistence.Extensions;

internal static partial class InfrastructureServicesExtension
{
    public static void ConfigureRepositoriesServices(this IServiceCollection services)
    {
        services.AddScoped<IRepository<Student>, Repository<Student>>();
    }

    public static void ConfigureDatabaseServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("SQLite");
        services.AddDbContext<DataContext>(options => options.UseSqlite(connectionString));
        services.AddDatabaseDeveloperPageExceptionFilter();
    }
}
