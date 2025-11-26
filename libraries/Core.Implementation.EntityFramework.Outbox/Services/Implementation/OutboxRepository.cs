using Core.Implementation.EntityFramework.Outbox.Entities;
using Core.Implementation.EntityFramework.Outbox.Services.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Core.Implementation.EntityFramework.Outbox.Services.Implementation;

internal class OutboxRepository<TDbContext>(TDbContext dbContext) 
    : IOutboxRepository where TDbContext : DbContext
{
    private readonly DbSet<OutboxMessage> _messagesRepository = dbContext.Set<OutboxMessage>();

    public async Task AddAsync(OutboxMessage message, CancellationToken cancellationToken)
    {
        await _messagesRepository.AddAsync(message);
    }

    public async Task ExecuteDeleteRange(IEnumerable<Guid> ids, CancellationToken cancellationToken)
    {
        await _messagesRepository
            .Where(x => ids.Contains(x.Id))
            .ExecuteDeleteAsync(cancellationToken);
    }

    public async Task ExecuteIncrementAttempts(IEnumerable<Guid> ids, CancellationToken cancellationToken)
    {
        await _messagesRepository
            .Where(x => ids.Contains(x.Id))
            .ExecuteUpdateAsync(x => x.SetProperty(p => p.Atempts, p => p.Atempts + 1), cancellationToken);
    }

    public async Task<IEnumerable<OutboxMessage>> GetRangeAsync(int? limit, int? attemptsLimit, CancellationToken cancellationToken)
    {
        var query = _messagesRepository.AsQueryable();

        if(limit.HasValue)
        {
            query = query.Take(limit.Value);
        }

        if (attemptsLimit.HasValue)
        {
            query = query.Where(x => x.Atempts <= attemptsLimit.Value);
        }

        return await query.ToListAsync(cancellationToken);
    }
}
