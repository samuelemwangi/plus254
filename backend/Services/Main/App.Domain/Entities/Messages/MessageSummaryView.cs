/// <summary>
/// Message Summary
/// </summary>

namespace App.Domain.Entities.Messages
{
    public class MessageSummaryView
    {
        public long MessageId { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string MessageContent { get; set; }

    }
}
