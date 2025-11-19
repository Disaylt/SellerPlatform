using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.Implementation.EntityFramework.Abstraction;

public interface IDomainEventsStore
{
    INotification? GetOrDefaultEvent(EntityState entityState, object entity);
}
