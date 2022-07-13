using Api.Contracts;
using Api.Contracts.ServiceContracts;
using Api.Repositories;
using Api.Services;
using Microsoft.EntityFrameworkCore;

namespace Api.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureCors(this IServiceCollection services) => services.AddCors(options =>
        options.AddPolicy("CorsPolicy",
            builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));

    public static void ConfigureIis(this IServiceCollection services) => services.Configure<IISOptions>(options => { });

    public static void ConfigureDb(this IServiceCollection services, IConfiguration configuration) =>
        services.AddDbContextPool<ApplicationContext>(
            builder => builder.UseNpgsql(configuration.GetConnectionString("DbConnection"))
                .UseSnakeCaseNamingConvention()
                .EnableSensitiveDataLogging());
    

    public static void ConfigureRepositoryManager(this IServiceCollection services) =>
        services.AddScoped<IRepositoryManager, RepositoryManager>();

    public static void ConfigureServiceManager(this IServiceCollection services) =>
        services.AddScoped<IServiceManager, ServiceManager>();
    
}