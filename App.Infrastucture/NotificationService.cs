using App.Application.EntitiesCommandsQueries.Notifications.Queries.GetNotification;
using App.Application.Interfaces;
using FluentEmail.Core;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace App.Infrastructure
{
    public class NotificationService : INotificationService
    {
        private readonly IFluentEmail _emailService;

        public NotificationService(IServiceProvider serviceProvider)
        {
            _emailService = serviceProvider.GetService<IFluentEmail>();

        }
        public Task SendAsync(NotificationViewModel notification)
        {
            //await _emailService
            //    .To(notification.SentTo)
            //    .Subject(notification.Subject)
            //    .Body(notification.NotificationMessage)
            //    .SendAsync();

            //Implement Sending mail , add to Queue maybe

            return Task.CompletedTask;
        }
    }
}
