using Account.Users.Domain.Entities;

namespace Account.Users.Application.Features.Sessions.Services.Abstraction;

public interface ISessionService
{
    Task<Session> CreateAsync(Session session, CancellationToken ct);
    Task<Session?> FindAsync(string id);
    Task UpdateAsync(Session session, CancellationToken ct);
}
