using App.Application.Exceptions;
using App.Domain.Entities;
using App.Persistence;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace App.Application.EntitiesCommandsQueries.Notifications.Queries.GetNotification
{
    public class GetNotificationQueryHandler : IRequestHandler<GetNotificationQuery, NotificationViewModel>
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public GetNotificationQueryHandler(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;

        }
        public async Task<NotificationViewModel> Handle(GetNotificationQuery request, CancellationToken cancellationToken)
        {
            var notification = _mapper.Map<NotificationViewModel>
                (
                    await _appDbContext.Notifications
                    .Where(e => e.ID == request.ID && e.Deleted != 1)
                    .Select(NotificationViewModel.Projection)
                    .FirstOrDefaultAsync(cancellationToken)
                );


            if (notification == null)
            {
                throw new NotFoundException(nameof(Notification), request.ID);
            }


            return notification;

        }
    }
}
