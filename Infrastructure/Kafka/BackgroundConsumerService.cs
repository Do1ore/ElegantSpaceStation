using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Kafka;


public class BackgoundConsumerService : BackgroundService
{
    private readonly KafkaConsumerService _kafkaConsumer;
    private readonly ILogger<BackgoundConsumerService> _logger;

    private readonly string _topic;
    private readonly int _delayTime;
    public BackgoundConsumerService(
        KafkaConsumerService kafkaConsumer,
        IConfiguration configuration,
        ILogger<BackgoundConsumerService> logger
    )
    {
        _kafkaConsumer = kafkaConsumer;

        _topic = configuration.GetSection("Kafka")["Topic"]
            ?? throw new ArgumentNullException("No topic found");

        _delayTime = int.Parse(configuration.GetSection("BackgoundService")["DelayTimeMs"]
            ?? throw new ArgumentNullException("No DelayTimeMs found")) - 1;

        _logger = logger;
    }

    public override Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("{@ServiceName} started", nameof(BackgoundConsumerService));
        return base.StartAsync(cancellationToken);
    }

    public override Task StopAsync(CancellationToken cancellationToken)
    {

        return base.StopAsync(cancellationToken);
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var result = _kafkaConsumer.Consume(_topic);
        _logger.LogInformation("Consume result: {@Key}; {@Message}; {@Headers}", result.Key, result.Message, result.Headers);
        await Task.Delay(_delayTime);
    }


}
