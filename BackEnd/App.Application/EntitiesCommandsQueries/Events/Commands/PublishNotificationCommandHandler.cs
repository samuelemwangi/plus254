using App.Application.Enums;
using App.Application.Interfaces.FileOperations;
using App.Application.Interfaces.Notifications;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// 
/// </summary>

namespace App.Application.EntitiesCommandsQueries.Events.Commands
{
    public class PublishNotificationCommand : INotification
    {
        public string Subject { get; set; }
        public NotificationType NotificationType { get; set; }
        public Dictionary<string, string> VariablesToReplace { get; set; }
        public string RecipientEmail { get; set; }
        public string RecipientName { get; set; }
        public bool ShowSenderTitleInSubject { get; set; }

    }

    public class PublishNotificationCommandHandler : INotificationHandler<PublishNotificationCommand>
    {
        private readonly INotificationService _notificationService;
        private readonly IFileUtils _fileUtils;
        private readonly ILogger<PublishNotificationCommandHandler> _publishNotificationLogger;
        private readonly IConfigurationSection _configurationSection;
        public PublishNotificationCommandHandler(
            INotificationService notificationService,
            IFileUtils fileUtils,
            ILogger<PublishNotificationCommandHandler> publishNotificationLogger,
            IConfiguration configuration
            )
        {
            _notificationService = notificationService;
            _fileUtils = fileUtils;
            _publishNotificationLogger = publishNotificationLogger;
            _configurationSection = configuration.GetSection("MailSettings");
        }
        public async Task Handle(PublishNotificationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                string filePath = _configurationSection["TemplatesFolder"] + Path.DirectorySeparatorChar + request.NotificationType.ToString().ToLower() + ".html";

                string mailText = await _fileUtils.ReadFileAsync(filePath);

                foreach (var item in request.VariablesToReplace)
                {
                    mailText = mailText.Replace("{{" + item.Key + "}}", item.Value);

                }

                // Replace Sender Title
                mailText = mailText.Replace("{{sender_title}}", _configurationSection["SenderTitle"]);

                await _notificationService.SendEmailAsync(request.Subject, mailText, request.RecipientEmail, request.RecipientName, request.ShowSenderTitleInSubject);

            }
            catch (Exception e)
            {
                _publishNotificationLogger.LogError(e.StackTrace);
            }


        }

    }
}
