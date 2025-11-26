using System.Text.Json;
using Core.Abstraction.Interfaces;
using Core.Implementation.EntityFramework.Outbox.Entities;
using Core.Implementation.EntityFramework.Outbox.Services.Abstract;

namespace Core.Implementation.EntityFramework.Outbox.Services.Implementation;

internal class OutboxEventBus(IOutboxRepository outboxRepository) : IEventBus
{
    public async Task SendEventAsync<TEvent>(TEvent @event, CancellationToken ct)
    {
        var type = typeof(TEvent).FullName ?? throw new ArgumentNullException("Event full name is null");
        var payload = JsonSerializer.Serialize(@event);

        var message = new OutboxMessage(type, payload);

        await outboxRepository.AddAsync(message, ct);
    }
}
