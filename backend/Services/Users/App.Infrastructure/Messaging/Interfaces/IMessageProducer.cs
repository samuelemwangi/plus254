using System.Threading.Tasks;

/// <summary>
/// 
/// </summary>

namespace App.Infrastructure.Messaging.Interfaces
{
    public interface IMessageProducer<in TKey, in TValue> where TValue : class
    {
        public Task ProduceAsync(string Topic, TKey Key, TValue Value);
    }
}
