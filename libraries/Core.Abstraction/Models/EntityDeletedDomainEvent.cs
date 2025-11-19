namespace Core.Abstraction.Models;

public record EntityDeletedDomainEvent<TEntity>(TEntity Entity) 
    : BaseEntityActionDomainEvent<TEntity>(Entity)
    where TEntity : class;
