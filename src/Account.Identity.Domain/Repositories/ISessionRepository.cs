using Account.Identity.Domain.Entities;

namespace Account.Identity.Domain.Repositories;

public interface ISessionRepository
{
    Task AddAsync(Session session, CancellationToken ct);
    Task DeleteAsync(Session session, CancellationToken ct);
    Task<Session> FindAsync(string id);
}
