using Confluent.Kafka;
using Infrastructure.Abstractions;
using Infrastructure.EfCore;
using Infrastructure.Implementation;
using Infrastructure.Kafka;
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
        services.AddHostedService<BackgroundConsumerService>();

    }
    public static void ConfigureKafka(this IServiceCollection services, IConfiguration configuration)
    {

        var bootstrapServers = configuration.GetSection("Kafka")["BootstrapServers"] ?? throw new ArgumentException("BootstrapServers not found");
        var groupId = configuration.GetSection("Kafka")["GroupId"] ?? throw new ArgumentException("GroupId not found");
        var consumerConfig = new ConsumerConfig
        {
            BootstrapServers = bootstrapServers,
            GroupId = groupId,
            AutoOffsetReset = AutoOffsetReset.Earliest
        };

        services.AddSingleton(new KafkaConsumerService(consumerConfig));

    }


}

