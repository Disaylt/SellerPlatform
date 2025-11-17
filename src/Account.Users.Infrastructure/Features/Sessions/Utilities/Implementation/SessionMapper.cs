using Account.Users.Domain.Entities;
using Account.Users.Infrastructure.Features.Sessions.Models;
using Account.Users.Infrastructure.Features.Sessions.Utilities.Abstraction;

namespace Account.Users.Infrastructure.Features.Sessions.Utilities.Implementation;

public class SessionMapper : ISessionMapper
{
    public SessionEntity ToEntity(Session session)
    {
        return new SessionEntity
        {
            CorrelationId = session.CorrelationId,
            Updated = session.Updated,
            IsActive = session.IsActive,
            UserId = session.UserId,
            LastUse = session.LastUse,
            Id = session.Id,
        };
    }

    public Session ToModel(SessionEntity session)
    {
        return new Session
        {
            Id = session.Id,
            UserId = session.UserId,
            LastUse = session.LastUse,
            CorrelationId = session.CorrelationId,
            Created = session.Created,
            IsActive = session.IsActive,
            Updated = session.Updated
        };
    }
}
