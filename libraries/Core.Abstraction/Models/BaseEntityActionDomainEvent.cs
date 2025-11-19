using MediatR;

namespace Core.Abstraction.Models;

public abstract record BaseEntityActionDomainEvent<TEntity>(TEntity Entity) 
    : INotification
    where TEntity : class;
