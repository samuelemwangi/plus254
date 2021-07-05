using App.Application.Interfaces.Messaging;
using App.Infrastructure.Messaging.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

/// <summary>
/// 
/// </summary>

namespace App.Infrastructure.Messaging
{
    public class MessagingService<TKey, TValue> : IMessagingService<TKey, TValue> where TValue : class
    {
        private readonly IMessageProducer<TKey, TValue> _emailMessageProducer;
        private readonly IConfigurationSection _configurationSection;
        private readonly ILogger<MessagingService<TKey, TValue>> _messagingServiceLogger;
        public MessagingService(
            IMessageProducer<TKey, TValue> emailMessageProducer,
            IConfiguration configuration,
            ILogger<MessagingService<TKey, TValue>> messagingServiceLogger

            )
        {
            _emailMessageProducer = emailMessageProducer;
            _configurationSection = configuration.GetSection("Messaging");
            _messagingServiceLogger = messagingServiceLogger;
        }
        public async Task HandleMessageAsync(string MessageType, TKey Key, TValue Value)
        {
            try
            {
                string TopicName = _configurationSection.GetSection("MessageTypes")[MessageType];

                await _emailMessageProducer.ProduceAsync(TopicName, Key, Value);

                _messagingServiceLogger.LogInformation("Message producuded to topic " + TopicName);
            }
            catch (Exception e)
            {

                _messagingServiceLogger.LogError(e.StackTrace);
            }

        }
    }
}
