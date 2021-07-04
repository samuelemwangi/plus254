using App.Application.Interfaces.Messaging;
using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App.Infrastructure.Messaging
{
    public class MessageConsumer<TKey, TValue> : IMessageConsumer<TKey, TValue> where TValue : class
    {
        private readonly ConsumerConfig _config;
        private IKafkaHandler<TKey, TValue> _handler;
        private IConsumer<TKey, TValue> _consumer;
        private string _topic;

        public void Close()
        {
            throw new NotImplementedException();
        }

        public Task Consume(string topic, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
