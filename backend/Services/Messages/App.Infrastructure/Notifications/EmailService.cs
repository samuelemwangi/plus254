using App.Application.Interfaces.Notifications;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;
using MediatR;
using App.Domain.Enums;
using App.Application.EntitiesCommandsQueries.NotificationMessages.Commands.UpdateNotificationMessage;

namespace App.Infrastructure.Notifications
{
    public class EmailService : IEmailService
    {
        private readonly ILogger<EmailService> _logger;
        private readonly IConfigurationSection _configurationSection;
        private readonly IConfiguration _configuration;
        private readonly IMediator _mediator;
        public EmailService(ILogger<EmailService> logger, IConfiguration configuration, IMediator mediator)
        {
            _logger = logger;
            _configurationSection = configuration.GetSection("MailSettings");
            _configuration = configuration;
            _mediator = mediator;
        }

        public async Task SendEmailAsync(
            string messageRefId,
            string subject,
            string messageContent,
            string senderEmail,
            string recipientEmail,
            string recipientName,
            bool showSenderTitleInSubject,
            NotificationMessageType notificationMessageType
            )
        {
            try
            {
                // Set Subject 
                if (showSenderTitleInSubject) subject = _configurationSection["SenderTitle"] + " - " + subject;

                // Set up email
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse(senderEmail));
                email.To.Add(MailboxAddress.Parse(recipientEmail));

                email.Subject = subject;

                email.Body = new TextPart(TextFormat.Html) { Text = messageContent };

                // send email
                string smtPServer = _configuration["SMTP_SERVER"] ?? _configurationSection["SMTPServer"];
                string smtpPort = _configuration["SMTP_PORT"] ?? _configurationSection["SMTPPort"];
                string smtpUser = _configuration["SMTP_USER_NAME"] ?? _configurationSection["SMTPUserName"];
                string smtpUserPassword = _configuration["SMTP_USER_PASSWORD"] ?? _configurationSection["SMTPUserPassword"];

                bool enableTLS = _configurationSection["EnableTLS"].ToUpper().Contains("TRUE");

                using var smtpClient = new SmtpClient();
                await smtpClient.ConnectAsync(smtPServer, int.Parse(smtpPort), enableTLS);
                await smtpClient.AuthenticateAsync(smtpUser, smtpUserPassword);
                await smtpClient.SendAsync(email);
                await smtpClient.DisconnectAsync(true);

                //Log if allowed
                if (_configurationSection["LogMailMessages"].ToUpper().Contains((notificationMessageType + "").ToUpper()))
                {
                    await _mediator.Publish(new UpdateNotificationMessageCommand
                    {
                        MessageRefId = messageRefId,
                        MessageStatus = NotificationMessageStatus.SENT

                    });
                }

            }
            catch (Exception e)
            {
                //Log if allowed
                if (_configurationSection["LogMailMessages"].ToUpper().Contains((notificationMessageType + "").ToUpper()))
                {
                    await _mediator.Publish(new UpdateNotificationMessageCommand
                    {
                        MessageRefId = messageRefId,
                        MessageStatus = NotificationMessageStatus.FAILED

                    });
                }

                _logger.LogError(e.Message, e.StackTrace);
            }
        }
    }
}
