using App.Application.Interfaces.Utilities;
using App.Domain.Enums;
using App.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App.Application.EntitiesCommandsQueries.NotificationMessages.Commands.UpdateNotificationMessage
{
    public class UpdateNotificationMessageCommand : INotification
    {
        public NotificationMessageStatus MessageStatus { get; set; }
        public string MessageRefId { get; set; }

    }
    internal sealed class UpdateNotificationMessageCommandHandler : INotificationHandler<UpdateNotificationMessageCommand>
    {
        private readonly AppDbContext _appDbContext;
        private readonly ILogger<UpdateNotificationMessageCommandHandler> _logger;
        private readonly IConfigurationSection _configurationSection;
        private readonly IMachineDateTime _machinedDateTime;

        public UpdateNotificationMessageCommandHandler(
            AppDbContext appDbContext, 
            ILogger<UpdateNotificationMessageCommandHandler> logger,
            IConfiguration configuration,
            IMachineDateTime machinedDateTime
            )
        {
            _appDbContext = appDbContext;
            _logger = logger;
            _configurationSection = configuration.GetSection("MessageTemplates");
            _machinedDateTime = machinedDateTime;
        }
        public async Task Handle(UpdateNotificationMessageCommand notification, CancellationToken cancellationToken)
        {
            try
            {
                var notificationMessage = await _appDbContext.Notification
                    .Where(e => e.RefId == notification.MessageRefId)
                    .FirstOrDefaultAsync(cancellationToken);

                if (notificationMessage == null) throw new Exception(_configurationSection["ItemDetailsNotFound"]);

                var messageStatus = await _appDbContext.NotificationStatus
                    .Where(e => e.StatusName.ToUpper().Contains((notification.MessageStatus + "").ToUpper()))
                    .FirstOrDefaultAsync(cancellationToken);

                if (messageStatus == null) throw new Exception("Target Status does not exist - " + notification.MessageStatus);

                notificationMessage.StatusId = messageStatus.Id;
                notificationMessage.LastEditedDate = _machinedDateTime.Now;

                _appDbContext.Notification.Update(notificationMessage);

                await _appDbContext.SaveChangesAsync(cancellationToken);
            }
            catch (Exception e)
            {
                _logger.LogError(e.StackTrace);
            }
        }
    }
}
