using Core.Implementation.EntityFramework.Outbox.Entities;

namespace Core.Implementation.EntityFramework.Outbox.Services.Abstract;

public interface IOutboxRepository
{
    Task AddAsync(OutboxMessage message, CancellationToken cancellationToken);
    Task<IEnumerable<OutboxMessage>> GetRangeAsync(int? limit, int? attemptsLimit, CancellationToken cancellationToken);
    Task ExecuteIncrementAttempts(IEnumerable<Guid> ids, CancellationToken cancellationToken);
    Task ExecuteDeleteRange(IEnumerable<Guid> ids, CancellationToken cancellationToken);
}
