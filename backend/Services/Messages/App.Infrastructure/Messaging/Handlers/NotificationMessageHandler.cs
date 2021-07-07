using App.Application.EntitiesCommandsQueries.NotificationMessages.Commands.CreateNotificationMessage;
using App.Application.EntitiesCommandsQueries.NotificationMessages.Queries.ViewModels;
using App.Application.Interfaces.FileOperations;
using App.Application.Interfaces.Notifications;
using App.Application.Interfaces.Utilities;
using App.Domain.Enums;
using App.Infrastructure.Messaging.Interfaces;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

/// <summary>
/// 
/// </summary>

namespace App.Infrastructure.Messaging.Handlers
{
    public class NotificationMessageHandler : IMessageHandler<string, NotificationMessageDTO>
    {
        private readonly ILogger<NotificationMessageHandler> _notificationMessageHandlerLogger;
        private readonly IFileUtils _fileUtils;
        private readonly IMediator _mediator;
        private readonly IConfigurationSection _configurationSection;
        private readonly IStringUtils _stringUtils;
        private readonly IEmailService _emailService;

        public Dictionary<string, string> emailVariables = new();

        public NotificationMessageHandler(
            ILogger<NotificationMessageHandler> notificationMessageHandlerLogger,
            IFileUtils fileUtils,
            IMediator mediator,
            IConfiguration configuration,
            IStringUtils stringUtils,
            IEmailService emailService
            )
        {
            _notificationMessageHandlerLogger = notificationMessageHandlerLogger;
            _fileUtils = fileUtils;
            _mediator = mediator;
            _configurationSection = configuration.GetSection("MailSettings");
            _stringUtils = stringUtils;
            _emailService = emailService;
        }
        public async Task HandleAsync(string key, NotificationMessageDTO value)
        {
            try
            {
                string filePath = _configurationSection["TemplatesFolder"] + Path.DirectorySeparatorChar + value.NotifType + ".html";
                string messageText = await _fileUtils.ReadFileAsync(filePath);


                // Get link Uri
                string linkUri = (value.NotifType + "").ToLower().Replace('_', '-');
                string link = _configurationSection["FrontEndUrlPrefix"] + "/" + linkUri + "/" + value.MessageLink;

                //Get Message Title
                string messageTitle = _stringUtils.Capitalize((value.NotifType + "").Replace('_', ' '));



                // Replace Messages
                messageText = messageText.Replace("{{message_desc}}", value.CustomMessage);
                messageText = messageText.Replace("{{user_name}}", value.RecipientName);

                messageText = messageText.Replace("{{link}}", link);

                messageText = messageText.Replace("{{sender_title}}", _configurationSection["SenderTitle"]);


                // use ref Id to track
                string RefId = Guid.NewGuid() + "";


                // log details if in whitelist

                if (_configurationSection["LogMailMessages"].ToUpper().Contains((value.NotifType + "").ToUpper()))
                {
                    await _mediator.Publish(new CreateNotificationMessageCommand
                    {
                        RefId = RefId,
                        MessageBody = messageText,
                        Recipient = value.Recipient,
                        RecipientName = value.RecipientName,
                        MessageStatus = NotificationMessageStatus.PREPARED + "",
                        MessageSubject = messageTitle,
                        MessageType = value.MessageType,
                        Sender = _configurationSection["SenderMail"]

                    });
                }

                bool showSenderInTitle = value.NotifType != NotificationMessageType.HIRE_US;

                messageTitle = showSenderInTitle ? messageTitle : _configurationSection["DefaultTitle"];

                // Send Message 
                await _emailService.SendEmailAsync(RefId,
                    messageTitle,
                    messageText,
                    _configurationSection["SenderMail"],
                    value.Recipient,
                    value.RecipientName,
                    showSenderInTitle,
                    value.NotifType
                    );
            }
            catch (Exception e)
            {

                _notificationMessageHandlerLogger.LogError(e.StackTrace);
            }

            

        }


    }
}
