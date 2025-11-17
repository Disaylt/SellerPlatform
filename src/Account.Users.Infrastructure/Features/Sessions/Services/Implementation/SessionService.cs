using Account.Users.Application.Features.Sessions.Services.Abstraction;
using Account.Users.Domain.Entities;
using Account.Users.Infrastructure.Database;
using Account.Users.Infrastructure.Features.Sessions.Utilities.Abstraction;

namespace Account.Users.Infrastructure.Features.Sessions.Services.Implementation;

public class SessionService(
    EfCoreUsersDbContext efCoreUsersDbContext,
    ISessionMapper sessionMapper)
    : ISessionService
{
    public async Task<Session> CreateAsync(Session session, CancellationToken ct)
    {
        var entity = sessionMapper.ToEntity(session);
        await efCoreUsersDbContext.Sessions.AddAsync(entity, ct);

        return sessionMapper.ToModel(entity);
    }

    public async Task<Session?> FindAsync(string id)
    {
        var entity = await efCoreUsersDbContext.Sessions.FindAsync(id);

        return entity is null 
            ? null 
            : sessionMapper.ToModel(entity);
    }

    public async Task UpdateAsync(Session session, CancellationToken ct)
    {
        var entity = sessionMapper.ToEntity(session);
        await efCoreUsersDbContext.Sessions.AddAsync(entity, ct);
    }
}
