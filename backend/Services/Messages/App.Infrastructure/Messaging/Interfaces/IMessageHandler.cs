using System.Threading.Tasks;

namespace App.Infrastructure.Messaging.Interfaces
{
    public interface IMessageHandler<TKey, TValue>
    {
        Task HandleAsync(TKey key, TValue value);
    }
}
