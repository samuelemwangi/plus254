using System.Threading.Tasks;

namespace App.Application.Interfaces.Messaging
{
    public interface IMessageHandler<TKey, TValue>
    {
        Task HandleAsync(TKey key, TValue value);
    }
}
