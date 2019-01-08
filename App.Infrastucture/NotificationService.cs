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
        public async Task SendAsync(NotificationViewModel notification)
        {
            try
            {

                await _emailService
               .To(notification.SentTo)
               .Subject(notification.Subject)
               .Body(notification.NotificationMessage)
               .SendAsync();
            }
            catch (Exception ex)
            {

                return;
            }
            //Implement Sending mail , add to Queue maybe

        }
    }
}
