
namespace Core.Abstraction.Interfaces;

public interface IEventBus
{
    Task SendEventAsync<TEvent>(TEvent @event, CancellationToken ct);
}
