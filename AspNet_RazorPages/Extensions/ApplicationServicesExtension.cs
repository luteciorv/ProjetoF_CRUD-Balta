using AspNet_RazorPages.Data;
using AspNet_RazorPages.Entities;
using AspNet_RazorPages.Interfaces.Repositories;
using AspNet_RazorPages.Interfaces.Services;
using AspNet_RazorPages.Repositories;
using AspNet_RazorPages.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AspNet_RazorPages.Extensions
{
    public static class ApplicationServicesExtension
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IRepository<Student>, Repository<Student>>();
        }

        public static void ConfigureDatabaseServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("SQLite");
            services.AddDbContext<DataContext>(options => options.UseSqlite(connectionString));
            services.AddDatabaseDeveloperPageExceptionFilter();
        }

        public static void ConfigureIdentityServices(this IServiceCollection services)
        {
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<DataContext>();
        }
    }
}
