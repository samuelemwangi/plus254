using App.Application.EntitiesCommandsQueries.Events.Queries.ViewModels;
using App.Application.Interfaces.Messaging;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace App.Infrastructure.Messaging.Handlers
{
    public class NotificationMessageHandler : IMessageHandler<string, NotificationMessageDTO>
    {
        private readonly ILogger<NotificationMessageHandler> _notificationMessageHandlerLogger;
        public NotificationMessageHandler(ILogger<NotificationMessageHandler> notificationMessageHandlerLogger)
        {
            _notificationMessageHandlerLogger = notificationMessageHandlerLogger;
        }
        public async Task HandleAsync(string key, NotificationMessageDTO value)
        {

            _notificationMessageHandlerLogger.LogInformation("\n\n\n");
            _notificationMessageHandlerLogger.LogInformation($"{value.RecipientEmail} -- {value.RecipientName} -- {value.EmailLink} -- {value.NotificationType}");
            _notificationMessageHandlerLogger.LogInformation("\n\n\n");

        }
    }
}
