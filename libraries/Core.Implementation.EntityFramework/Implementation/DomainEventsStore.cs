using Core.Implementation.EntityFramework.Abstraction;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.Implementation.EntityFramework.Implementation;

public class DomainEventsStore(IEnumerable<IDomainEventRecord> domainEventRecords) : IDomainEventsStore
{
    Dictionary<EntityState, Dictionary<Type, IDomainEventRecord>> _recodsByStateThenByType = domainEventRecords
        .GroupBy(x => x.State)
        .ToDictionary(
            g => g.Key,
            g => g.ToDictionary(r => r.Type));

    public INotification? GetOrDefaultEvent(EntityState entityState, object entity)
    {
        var type = entity.GetType();

        return _recodsByStateThenByType
            .GetValueOrDefault(entityState)?
            .GetValueOrDefault(type)?
            .Create(entity);
    }
}
