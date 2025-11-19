using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.Implementation.EntityFramework.Abstraction;

public interface IDomainEventRecord
{
    public Type Type { get; }
    public EntityState State { get; }
    public INotification Create(object entity);
}
