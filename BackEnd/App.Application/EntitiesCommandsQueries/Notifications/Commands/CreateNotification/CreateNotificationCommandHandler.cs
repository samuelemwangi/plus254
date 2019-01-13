using App.Common.Interfaces;
using App.Domain.Entities;
using App.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;



namespace App.Application.EntitiesCommandsQueries.Notifications.Commands.CreateNotification
{
    public class CreateNotificationCommandHandler : IRequestHandler<CreateNotificationCommand, long>
    {
        private readonly AppDbContext _appDbContext;
        private readonly IDateTime _dateTime;

        private readonly IMediator _mediator;


        public CreateNotificationCommandHandler(AppDbContext appDbContext, IDateTime dateTime, IMediator mediator)
        {
            _appDbContext = appDbContext;
            _dateTime = dateTime;
            _mediator = mediator;

        }


        public async Task<long> Handle(CreateNotificationCommand request, CancellationToken cancellationToken)
        {
            var entity = new Notification
            {
                From = request.From,
                To = request.To,
                Subject = request.Subject,
                Body = request.Body,
                CreatedDate = _dateTime.Now,
                LastEditedDate = _dateTime.Now

            };

            _appDbContext.Notifications.Add(entity);

            await _appDbContext.SaveChangesAsync(cancellationToken);

            await _mediator.Publish(new NotificationCreated { ID = entity.ID });

            return entity.ID;
        }
    }
}
