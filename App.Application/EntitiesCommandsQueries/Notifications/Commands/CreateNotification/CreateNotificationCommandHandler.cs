using System.Threading;
using System.Threading.Tasks;
using MediatR;
using App.Domain.Entities;
using App.Persistence;
using App.Common.Interfaces;

namespace App.Application.EntitiesCommandsQueries.Notifications.Commands.CreateNotification
{
    public class CreateNotificationCommandHandler : IRequestHandler<CreateNotificationCommand, long>
    {
        private readonly AppDbContext _appDbContext;
        private readonly IDateTime _dateTime;

        public CreateNotificationCommandHandler(AppDbContext appDbContext, IDateTime dateTime)
        {
            _appDbContext = appDbContext;
            _dateTime = dateTime;
        }
        

       public async Task<long> Handle(CreateNotificationCommand request, CancellationToken cancellationToken)
        {
            var entity = new Notification
            {
                From = request.From,
                To = request.To,
                Subject = request.Subject,
                Body = request.Body,
                CreatedDate =  _dateTime.Now               

            };

            _appDbContext.Notifications.Add(entity);
            await _appDbContext.SaveChangesAsync(cancellationToken);

            return entity.ID;
        }
    }
}
