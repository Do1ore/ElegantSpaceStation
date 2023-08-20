using Confluent.Kafka;

namespace Infrastructure.Kafka
{
    public class KafkaConsumerService
    {
        private readonly IConsumer<Ignore, string> _consumer;

        public KafkaConsumerService(ConsumerConfig consumerConfig)
        {
            _consumer = new ConsumerBuilder<Ignore, string>(consumerConfig).Build();
        }

        public ConsumeResult<Ignore, string> Consume(string topic)
        {
            _consumer.Subscribe(topic);
            var consumeResult = _consumer.Consume();

            return consumeResult;

        }
    }
}
