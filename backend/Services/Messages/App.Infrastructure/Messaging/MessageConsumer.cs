using App.Infrastructure.Messaging.Interfaces;
using Confluent.Kafka;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace App.Infrastructure.Messaging
{
    public class MessageConsumer<TKey, TValue> : IMessageConsumer<TKey, TValue> where TValue : class
    {
        private readonly ConsumerConfig _config;
        private IMessageHandler<TKey, TValue> _handler;
        private IConsumer<TKey, TValue> _consumer;
        private string _topic;


        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly ILogger<MessageConsumer<TKey, TValue>> _logger;
        public MessageConsumer(ConsumerConfig config, IServiceScopeFactory serviceScopeFactory, ILogger<MessageConsumer<TKey, TValue>> logger)
        {
            _serviceScopeFactory = serviceScopeFactory;
            _config = config;
            _logger = logger;
        }

        public async Task Consume(string topic, CancellationToken cancellationToken)
        {
            using var scope = _serviceScopeFactory.CreateScope();

            _handler = scope.ServiceProvider.GetRequiredService<IMessageHandler<TKey, TValue>>();
            _consumer = new ConsumerBuilder<TKey, TValue>(_config).SetValueDeserializer(new MessageDeserializer<TValue>()).Build();
            _topic = topic;

            await Task.Run(() => StartConsumerLoop(cancellationToken), cancellationToken);
        }

        private async Task StartConsumerLoop(CancellationToken cancellationToken)
        {
            _consumer.Subscribe(_topic);

            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    var result = _consumer.Consume(cancellationToken);

                    if (result != null)
                    {
                        await _handler.HandleAsync(result.Message.Key, result.Message.Value);
                    }
                }
                catch (OperationCanceledException)
                {
                    break;
                }
                catch (ConsumeException e)
                {
                    // Consumer errors should generally be ignored (or logged) unless fatal.                    
                    _logger.LogError($"Consume error: {e.Error.Reason}");

                    if (e.Error.IsFatal)
                    {
                        break;
                    }
                }
                catch (Exception e)
                {
                    _logger.LogError($"Unexpected error: {e.StackTrace}");                    
                    break;
                }
            }
        }

        public void Close()
        {
            _consumer.Close();
        }

        public void Dispose()
        {
            _consumer.Dispose();
        }
    }
}
