using App.Application.Exceptions;
using App.Domain.Entities;
using App.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using App.Common.Interfaces;

namespace App.Application.EntitiesCommandsQueries.Notifications.Commands.UpdateNotification
{
    public class UpdateNotificationCommandHandler : IRequestHandler<UpdateNotificationCommand, Unit>
    {
        private readonly AppDbContext _appDbContext;
        private readonly IDateTime _dateTime;

        public UpdateNotificationCommandHandler(AppDbContext appDbContext, IDateTime dateTime)
        {
            _appDbContext = appDbContext;
            _dateTime = dateTime;

        }

        public async Task<Unit> Handle(UpdateNotificationCommand request, CancellationToken cancellationToken)
        {
            var entity = await _appDbContext.Notifications
                .SingleAsync(e => e.ID == request.ID, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Notification), request.ID);
            }

            entity.MailQueued = request.MailQueued;
            entity.LastEditedDate = _dateTime.Now;

            _appDbContext.Notifications.Update(entity);

            await _appDbContext.SaveChangesAsync(cancellationToken);


            return Unit.Value;
        }
    }
}
