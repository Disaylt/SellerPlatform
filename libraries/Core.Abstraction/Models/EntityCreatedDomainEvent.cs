namespace Core.Abstraction.Models;

public record EntityCreatedDomainEvent<TEntity>(TEntity Entity) 
    : BaseEntityActionDomainEvent<TEntity>(Entity)
    where TEntity : class;
