using Core.Abstraction.Models;

namespace Core.Abstraction.Interfaces;

public interface IEventsServcie
{
    Task SendEventAsync(MessageEvent @event, CancellationToken ct);
    Task SendEventsAsync(IEnumerable<MessageEvent> @event, CancellationToken ct);
}
