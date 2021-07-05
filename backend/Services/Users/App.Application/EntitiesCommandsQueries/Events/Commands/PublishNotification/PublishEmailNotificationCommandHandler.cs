using App.Application.Interfaces.Messaging;
using App.Domain.Enums;
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
        public NotificationType NotifType { get; set; }
        public string EmailLink { get; set; }

    }
    internal sealed class PublishEmailNotificationCommandHandler : INotificationHandler<PublishEmailNotificationCommand>
    {
        private readonly IMessagingService<string, PublishEmailNotificationCommand> _messagingService;
        private readonly IConfigurationSection _configurationSection;
        private readonly ILogger<PublishEmailNotificationCommandHandler> _logger;
        public PublishEmailNotificationCommandHandler(
            IMessagingService<string, PublishEmailNotificationCommand> messagingService,
            IConfiguration configuration,
            ILogger<PublishEmailNotificationCommandHandler> logger
            )
        {
            _messagingService = messagingService;
            _configurationSection = configuration.GetSection("Messaging");
            _logger = logger;
        }
        public async Task Handle(PublishEmailNotificationCommand notification, CancellationToken cancellationToken)
        {
            try
            {
                await _messagingService.HandleMessageAsync(_configurationSection.GetSection("MessageTypes")["NotificationMessages"], null, notification);

            }
            catch (Exception e)
            {
                _logger.LogError(e.StackTrace);
            }


        }
    }
}
