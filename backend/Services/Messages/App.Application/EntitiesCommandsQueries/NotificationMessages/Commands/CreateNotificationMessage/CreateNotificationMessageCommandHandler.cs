using App.Application.Interfaces.Utilities;
using App.Domain.Entities.Notifications;
using App.Persistence;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace App.Application.EntitiesCommandsQueries.NotificationMessages.Commands.CreateNotificationMessage
{
    public class CreateNotificationMessageCommand : INotification
    {
        public string RefId { get; set; }
        public string MessageType { get; set; }
        public string MessageStatus { get; set; }
        public string Sender { get; set; }
        public string Recipient { get; set; }
        public string BCCRecipient { get; set; }
        public string CCRecipient { get; set; }
        public string RecipientName { get; set; }
        public string MessageSubject { get; set; }
        public string MessageBody { get; set; }

    }
    public class CreateNotificationMessageCommandHandler : INotificationHandler<CreateNotificationMessageCommand>
    {
        private readonly AppDbContext _appDbContext;
        private readonly ILogger<CreateNotificationMessageCommandHandler> _logger;
        private readonly IMachineDateTime _machineDateTime;
        private readonly IConfigurationSection _configurationSection;
        public CreateNotificationMessageCommandHandler(
            AppDbContext appDbContext, 
            ILogger<CreateNotificationMessageCommandHandler> logger, 
            IMachineDateTime machineDateTime,
            IConfiguration configuration
            )
        {
            _appDbContext = appDbContext;
            _logger = logger;
            _machineDateTime = machineDateTime;
            _configurationSection = configuration.GetSection("AppDetails");
        }
        public async Task Handle(CreateNotificationMessageCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Check if Message Type exist
                var messageType = _appDbContext.NotificationType
                    .Where(e => e.TypeName.ToUpper().Contains(request.MessageType.ToUpper()))
                    .FirstOrDefault();

                if (messageType == null) throw new Exception("Notification Type " + request.MessageType + " has not been created");

                // Check if Message Status Exist
                var messageStatus = _appDbContext.NotificationStatus
                    .Where(e => e.StatusName.ToUpper().Contains(request.MessageStatus.ToUpper()))
                    .FirstOrDefault();

                if (messageStatus == null) throw new Exception("Notification Status " + request.MessageStatus + " has not been created");

                var notificationMessage = new Notification
                {
                    RefId = request.RefId,
                    StatusId = messageStatus.Id,
                    TypeId = messageType.Id,
                    Recipient =  request.Recipient,
                    Sender =  request.Sender,
                    BCCRecipient = request.BCCRecipient,
                    CCRecipient =  request.CCRecipient,
                    Subject = request.MessageSubject,
                    Body = request.MessageBody,
                    CreatedDate = _machineDateTime.Now,
                    LastEditedDate = _machineDateTime.Now,
                    CreatedBy = _configurationSection["Name"],
                    LastEditedBy = _configurationSection["Name"]                    
                };

                _appDbContext.Add(notificationMessage);

                await _appDbContext.SaveChangesAsync(cancellationToken);

            }
            catch (Exception e)
            {
                _logger.LogError(e.StackTrace);

            }
        }

    }
}
