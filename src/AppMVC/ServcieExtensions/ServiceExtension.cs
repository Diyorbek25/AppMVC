using AppMVC.Application.Services.Products;
using AppMVC.Application.Services;
using AppMVC.Domain.Services;
using AppMVC.Infrastructure.Contexts;
using AppMVC.Infrastructure.Repositories.ProductAuditRepository;
using AppMVC.Infrastructure.Repositories.ProductAudits;
using AppMVC.Infrastructure.Repositories.Products;
using AppMVC.Infrastructure.Repositories.Users;
using Microsoft.EntityFrameworkCore;
using AppMVC.Application.Services.ProductAudits;

namespace AppMVC.ServcieExtensions;

public static class ServiceExtension
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContextPool<AppDbContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("SqlServer"))
            );

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IProductAuditRepository, ProductAuditRepository>();

        return services;
    }

    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        services.AddSingleton<IUserFactory, UserFactory>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IProductAuditService, ProductAuditService>();

        return services;
    }
}
