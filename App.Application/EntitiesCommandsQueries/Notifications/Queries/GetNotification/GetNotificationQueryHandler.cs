using App.Application.Exceptions;
using App.Domain.Entities;
using App.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;


namespace App.Application.EntitiesCommandsQueries.Notifications.Queries.GetNotification
{
    public class GetNotificationQueryHandler : IRequestHandler<GetNotificationQuery, NotificationViewModel>
    {
        private readonly AppDbContext _appDbContext;

        public GetNotificationQueryHandler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;

        }
        public async Task<NotificationViewModel> Handle(GetNotificationQuery request, CancellationToken cancellationToken)
        {
            var entity = await _appDbContext.Notifications.FindAsync(request.ID);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Notification), request.ID);
            }


            return new NotificationViewModel
            {
                SentFrom = entity.From,
                SentTo = entity.To,
                Subject = entity.Subject,
                NotificationMessage = entity.Body,
                CreatedBy = entity.CreatedBy + ""
            };



        }
    }
}
