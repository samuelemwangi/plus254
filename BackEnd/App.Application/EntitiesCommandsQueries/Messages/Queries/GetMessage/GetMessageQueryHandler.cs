using App.Application.EntitiesCommandsQueries.Messages.Queries.ViewModels;
using App.Persistence;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace App.Application.EntitiesCommandsQueries.Messages.Queries.GetMessage
{
    public class GetMessageQuery : BaseQuery, IRequest<MessageDetailViewModel>
    {
        public long MessageId { get; set; }

    }
    public class GetMessageQueryHandler : IRequestHandler<GetMessageQuery, MessageDetailViewModel>
    {
        private readonly AppDbContext _appDbContext;
        private readonly IConfigurationSection _configurationSection;

        public GetMessageQueryHandler(AppDbContext appDbContext, IConfiguration configuration)
        {
            _appDbContext = appDbContext;
            _configurationSection = configuration.GetSection("MessageTemplates");

        }
        public async Task<MessageDetailViewModel> Handle(GetMessageQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var message = await _appDbContext.MessagesSummary
                    .Where(e => e.MessageId == request.MessageId)
                    .Select(MessageDTO.Projection)
                    .FirstOrDefaultAsync(cancellationToken);

                if (message == null) throw new Exception(_configurationSection["ItemDetailsNotFound"]);

                return new MessageDetailViewModel
                {
                    MessageDetails = message,
                    RequestStatus = 1,
                    StatusMessage = _configurationSection["Success"],

                };

            }
            catch (Exception e)
            {
                return new MessageDetailViewModel
                {
                    RequestStatus = 0,
                    StatusMessage = e.Message

                };

            }
        }
    }
}
