using System.Threading.Tasks;

/// <summary>
/// 
/// </summary>

namespace App.Application.Interfaces.Messaging
{
    public interface IMessageProducer<in TKey, in TValue> where TValue : class
    {
        public Task ProduceAsync(string topic, TKey key, TValue value);
    }
}
