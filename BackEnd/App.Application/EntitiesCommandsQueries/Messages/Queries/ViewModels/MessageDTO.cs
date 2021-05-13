using App.Domain.Entities.Messages;
using System;
using System.Linq.Expressions;


namespace App.Application.EntitiesCommandsQueries.Messages.Queries.ViewModels
{
    public class MessageDTO : BaseEntityDTO
    {
        public long MessageId { get; set; }
        public string MessageContent { get; set; }
        public string Sender { get; set; }
        public string Reciever{ get; set; }

        public static Expression<Func<MessageSummaryView, MessageDTO>> Projection
        {
            get
            {
                return m => new MessageDTO
                {
                    MessageId = m.MessageId,
                    MessageContent = m.MessageContent,
                    Sender = m.Sender,
                    Reciever = m.Receiver
                };
            }

        }


    }
}
