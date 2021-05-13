using App.Application.Interfaces.Notifications;
using Mailjet.Client;
using Mailjet.Client.TransactionalEmails;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace App.Infrastructure.Notifications
{
    public class NotificationService : INotificationService
    {
        private readonly ILogger<NotificationService> _notificationServiceLogger;
        private readonly IConfigurationSection _configurationSection;
        private readonly MailjetClient _mailjetClient;

        public NotificationService(ILogger<NotificationService> notificationServiceLogger, IConfiguration configuration)
        {
            // Mail jet set up
            _notificationServiceLogger = notificationServiceLogger;
            _configurationSection = configuration.GetSection("MailSettings");
            _mailjetClient = new(_configurationSection["ApiKey"], _configurationSection["ApiSecret"]);
        }

        public async Task SendEmailAsync(string subject, string mailText, string recipientEmail, string recipientName, bool showSenderTitleInSubject)
        {
            try
            {

                string senderTitle = _configurationSection["SenderTitle"];

                if (showSenderTitleInSubject) subject = senderTitle + " - " + subject;


                var email = new TransactionalEmailBuilder()
                    .WithFrom(new SendContact(_configurationSection["SenderMail"], senderTitle))
                    .WithBcc(new SendContact(_configurationSection["SenderMail"]))
                    .WithSubject(subject)
                    .WithHtmlPart(mailText)
                    .WithHeader("Reply-To", _configurationSection["SenderMail"])
                    .WithTo(new SendContact(recipientEmail, recipientName))
                    .Build();


                var response = await _mailjetClient.SendTransactionalEmailAsync(email);

                var message = response.Messages[0];

                if (message.Status == "success")
                {
                    _notificationServiceLogger.LogInformation("MAIL ==> Sucessfully sent mail to " + recipientEmail);

                }
                else
                {
                    //_notificationServiceLogger.LogError("MAIL ==> Message Sending failed. Recipient " + recipientEmail + "Status Code ==> " + message.Status + " ErrorInfo ==> " + message.Errors.ToArray().ToString());
                    string errors = "";
                    foreach (var item in message.Errors)
                    {
                        errors += "{" + item.ErrorCode + ":" + item.ErrorMessage + " }";

                    }
                    _notificationServiceLogger.LogError("MAIL ==> Message Sending failed. Recipient " + recipientEmail + "Errors => " + errors);

                }
            }
            catch (Exception e)
            {

                _notificationServiceLogger.LogError(e.StackTrace);
            }



        }
    }
}
