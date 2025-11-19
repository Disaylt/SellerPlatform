using Core.Abstraction.Models;
using Core.Implementation.EntityFramework.Abstraction;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.Implementation.EntityFramework.Implementation;

public abstract class DomainBaseEventRecord<T>
    : IDomainEventRecord
    where T : class
{
    public Type Type => typeof(T);

    public abstract EntityState State { get; }

    public virtual INotification Create(object entity)
    {
        if (entity is T entry)
        {
            return new EntityCreatedDomainEvent<T>(entry);
        }

        throw new InvalidCastException($"Entity type is {entity.GetType().Name}. Expected type is {typeof(T).Name}");
    }
}
