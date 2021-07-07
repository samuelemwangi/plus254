using App.Domain.Enums;
using System.Threading.Tasks;

/// <summary>
/// 
/// </summary>

namespace App.Application.Interfaces.Notifications
{
    public interface IEmailService
    {
        Task SendEmailAsync(
            string messageRefId,
            string subject,
            string messageContent,
            string senderEmail,
            string recipientEmail,
            string recipientName,
            bool showSenderTitleInSubject,
            NotificationMessageType notificationMessageType
            );
    }
}
