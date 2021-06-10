﻿using System.Threading.Tasks;

namespace App.Application.Interfaces.Notifications
{
    public interface INotificationService
    {
        Task PublishNotificationAsync(string subject, string messageContent, string recipientEmail, string recipientName, bool showSenderTitleInSubject);
    }
}
