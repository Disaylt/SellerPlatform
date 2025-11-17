using Account.Users.Domain.Entities;
using Account.Users.Infrastructure.Features.Sessions.Models;

namespace Account.Users.Infrastructure.Features.Sessions.Utilities.Abstraction;

public interface ISessionMapper
{
    SessionEntity ToEntity(Session session);
    Session ToModel(SessionEntity session);
}
