using Account.Users.Domain.Entities;
using MediatR;

namespace Account.Users.Domain.Events;

public record CreatedUserDomainEvent(User User) : INotification { }
