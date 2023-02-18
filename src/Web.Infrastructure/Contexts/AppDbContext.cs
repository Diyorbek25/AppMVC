using Microsoft.EntityFrameworkCore;
using System.Reflection;
using AppMVC.Domain.Entities;

namespace AppMVC.Infrastructure.Contexts;

public class AppDbContext : DbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> options)
		: base(options)
	{
	}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            Assembly.GetExecutingAssembly());
    }

    DbSet<User> Users { get; set; }
    DbSet<Product> Products { get; set; }
    DbSet<ProductAudit> ProductAudits { get; set; }
}
