using Infrastructure.Abstractions;
using Infrastructure.EfCore;
using Infrastructure.Implementation;
using Microsoft.EntityFrameworkCore;

namespace Api.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureCustomServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("SqlLite") ??
                               throw new ArgumentException("Connection for SqlLite not found");

        services.AddDbContextFactory<AppDbContext>(
            options =>
            {
                options.UseSqlite(connectionString);
                options.LogTo(Console.WriteLine, LogLevel.Information);
            });

        services.AddScoped<IRoverLocationRepository, RoverLocationRepository>();
    }
}