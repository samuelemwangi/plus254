using App.Application.Interfaces.Messaging;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// Use this to publish notification
/// </summary>

namespace App.Application.EntitiesCommandsQueries.Events.Commands.PublishNotification
{
    internal sealed class PublishEmailNotificationCommand : INotification
    {
        public string RecipientEmail { get; set; }
        public string RecipientName { get; set; }
        public string NotificationType { get; set; }
        public string EmailLink { get; set; }

    }
    internal sealed class PublishEmailNotificationCommandHandler : INotificationHandler<PublishEmailNotificationCommand>
    {
        private readonly IMessageProducer<string, PublishEmailNotificationCommand> _emailMessageProducer;
        private readonly IConfigurationSection _configurationSection;
        private readonly ILogger<PublishEmailNotificationCommandHandler> _publishNotificationLogger;
        public PublishEmailNotificationCommandHandler(
            IMessageProducer<string, PublishEmailNotificationCommand> emailMessageProducer,
            IConfiguration configuration,
            ILogger<PublishEmailNotificationCommandHandler> publishNotificationLogger
            )
        {
            _emailMessageProducer = emailMessageProducer;
            _configurationSection = configuration.GetSection("Kafka");
            _publishNotificationLogger = publishNotificationLogger;
        }
        public async Task Handle(PublishEmailNotificationCommand notification, CancellationToken cancellationToken)
        {
            try
            {
                await _emailMessageProducer.ProduceAsync(_configurationSection.GetSection("Topics")["EmailNotifications"], null, notification);

                _publishNotificationLogger.LogInformation("Message producuded to topic " + _configurationSection.GetSection("Topics")["EmailNotifications"]);

            }
            catch (Exception e)
            {

                _publishNotificationLogger.LogError(e.StackTrace);
            }

        }
    }
}
