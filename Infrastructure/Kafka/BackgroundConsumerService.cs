﻿using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Kafka;

public class BackgroundConsumerService : BackgroundService
{
    private readonly KafkaConsumerService _kafkaConsumer;
    private readonly ILogger<BackgroundConsumerService> _logger;

    private readonly string _topic;
    private readonly int _delayTime;

    public BackgroundConsumerService(
        KafkaConsumerService kafkaConsumer,
        IConfiguration configuration,
        ILogger<BackgroundConsumerService> logger
    )
    {
        _kafkaConsumer = kafkaConsumer;

        _topic = configuration.GetSection("Kafka")["Topic"]
                 ?? throw new ArgumentNullException(nameof(_topic));

        _delayTime = int.Parse(configuration.GetSection("BackgroundService")["DelayTimeMs"]
                               ?? throw new ArgumentNullException(nameof(_delayTime))) - 1;

        _logger = logger;
    }

    public override Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("{@ServiceName} started", nameof(BackgroundConsumerService));
        return base.StartAsync(cancellationToken);
    }


    [Obsolete("Obsolete")]
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var result = _kafkaConsumer.Consume(_topic);
        _logger.LogInformation("Consume result: {@Key}; {@Message}; {@Headers}", result.Key, result.Message,
            result.Headers);
        await Task.Delay(_delayTime, stoppingToken);
    }
}