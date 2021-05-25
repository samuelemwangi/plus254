using App.Application.EntitiesCommandsQueries.Events.Commands;
using App.Application.EntitiesCommandsQueries.Messages.Queries.GetMessage;
using App.Application.EntitiesCommandsQueries.Messages.Queries.ViewModels;
using App.Application.EntitiesCommandsQueries.System.SeedDB.Messages;
using App.Application.Enums;
using App.Domain.Entities.Messages;
using App.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace App.Application.EntitiesCommandsQueries.Messages.Commands.CreateMessage
{
    public class CreateMessageCommand : IRequest<MessageDetailViewModel>
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Desc { get; set; }
        public short StatusId { get; set; }
    }
    public class CreateMessageCommandHandler : IRequestHandler<CreateMessageCommand, MessageDetailViewModel>
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMediator _mediator;
        public Dictionary<string, string> emailVariables = new();

        public CreateMessageCommandHandler(AppDbContext appDbContext, IMediator mediator)
        {
            _appDbContext = appDbContext;
            _mediator = mediator;
        }
        public async Task<MessageDetailViewModel> Handle(CreateMessageCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Check if message exists 
                var messageExists = await _appDbContext.Messages
                    .Where(e => e.SenderName == request.Email && e.MessageContent == request.Desc)
                    .AnyAsync(cancellationToken);

                if (messageExists) throw new Exception(request.Desc + " from " + request.Email + " exists");

                MessageStatusSeed messageStatusSeed = new();

                var messageStatus = await _appDbContext.MessageStatuses
                    .Where(e => e.StatusLabel == messageStatusSeed.successMesageStatus.StatusLabel)
                    .FirstOrDefaultAsync(cancellationToken);

                if (messageStatus == null) throw new Exception("DB not seeded - Message Status");

                var newMessage = new Message
                {
                    SenderName = request.Email,
                    RecipientName = request.Email,
                    MessageContent = request.Desc,
                    MessageStatusId = messageStatus.Id
                };

                _appDbContext.Messages.Add(newMessage);

                await _appDbContext.SaveChangesAsync(cancellationToken);


                // Email variables
                emailVariables.Add("message_desc", newMessage.MessageContent);


                await _mediator.Publish(new PublishNotificationCommand
                {
                    Subject = "Thank you for Contacting Upfik",
                    NotificationType = NotificationType.HIRE_US,
                    RecipientEmail = newMessage.RecipientName,
                    RecipientName = newMessage.RecipientName,
                    VariablesToReplace = emailVariables,
                    ShowSenderTitleInSubject = false,
                }, cancellationToken);

                return await _mediator.Send(new GetMessageQuery { MessageId = newMessage.Id }, cancellationToken);

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
