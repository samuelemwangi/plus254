using System.Threading.Tasks;

/// <summary>
/// 
/// </summary>

namespace App.Application.Interfaces.Messaging
{
    public interface IMessagingService<TKey, TValue> where TValue : class
    {
        public Task HandleMessageAsync(string MessageType, TKey Key, TValue Value);
    }
}
