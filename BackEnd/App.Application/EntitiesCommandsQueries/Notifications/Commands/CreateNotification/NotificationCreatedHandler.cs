using App.Application.EntitiesCommandsQueries.Notifications.Commands.UpdateNotification;
using App.Application.EntitiesCommandsQueries.Notifications.Queries.GetNotification;
using App.Application.Interfaces;
using App.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;


namespace App.Application.EntitiesCommandsQueries.Notifications.Commands.CreateNotification
{

    public class NotificationCreatedHandler : INotificationHandler<NotificationCreated>
    {

        private readonly INotificationService _notificationService;
        private readonly AppDbContext _appDbContext;
        private readonly IMediator _mediator;

        public NotificationCreatedHandler(INotificationService notificationService, AppDbContext appDbContext, IMediator mediator)
        {
            _notificationService = notificationService;
            _appDbContext = appDbContext;
            _mediator = mediator;
        }


        public async Task Handle(NotificationCreated notification, CancellationToken cancellationToken)
        {

            var entity = await _mediator.Send(new GetNotificationQuery { ID = notification.ID });


            await _notificationService.SendAsync(entity);

            await _mediator.Send(new UpdateNotificationCommand { ID = notification.ID, MailQueued = 1 });            

        }


    }

}