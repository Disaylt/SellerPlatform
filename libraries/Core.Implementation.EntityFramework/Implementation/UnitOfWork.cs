using Core.Abstraction.Interfaces;
using Core.Implementation.EntityFramework.Abstraction;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.Implementation.EntityFramework.Implementation;

public class UnitOfWork<TDbContext>(
    IMediator mediator,
    TDbContext dbContext, 
    IDomainEventsStore domainEventsStore)
    : IUnitOfWork
    where TDbContext : DbContext
{
    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        List<INotification> notifications = new List<INotification>();

        foreach(var entity in dbContext.ChangeTracker.Entries())
        {
            var notification = domainEventsStore.GetOrDefaultEvent(entity.State, entity.Entity);

            if(notification is not null)
            {
                notifications.Add(notification);
            }
        }

        await dbContext.SaveChangesAsync(cancellationToken);

        if (notifications.Count == 0) return;

        foreach (var notification in notifications)
        {
            await mediator.Publish(notification);
        }

        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
