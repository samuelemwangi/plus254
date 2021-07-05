using App.Application.EntitiesCommandsQueries.Events.Queries.ViewModels;
using App.Infrastructure.Messaging.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace App.Infrastructure.Messaging.Consumers
{
    public class NotificationMessageConsumer : BackgroundService
    {
        private readonly IMessageConsumer<string, NotificationMessageDTO> _messageConsumer;
        private readonly ILogger<NotificationMessageConsumer> _notificationMessageLogger;
        private readonly IConfigurationSection _configurationSection;
        public NotificationMessageConsumer(IMessageConsumer<string, NotificationMessageDTO> messageConsumer, IConfiguration configuration)
        {
            _messageConsumer = messageConsumer;
            _configurationSection = configuration.GetSection("Messaging");
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                await _messageConsumer.Consume(_configurationSection.GetSection("MessageTypes")["NotificationMessages"], stoppingToken);

            }
            catch (Exception e)
            {
                _notificationMessageLogger.LogError(e.StackTrace);

            }

        }
    }
}
