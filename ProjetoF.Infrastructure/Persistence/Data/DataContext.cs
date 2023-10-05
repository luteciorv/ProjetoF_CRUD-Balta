using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjetoF.Domain.Entities;

namespace ProjetoF.Infrastructure.Persistence.Data;

public class DataContext : IdentityDbContext
{
    public DataContext()
    { }

    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    { }

    public DbSet<Student> Students { get; set; } = default!;
    public DbSet<Subscription> Subscriptions { get; set; } = default!;
}